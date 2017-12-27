using Common.Extensions;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DayLibrary
{
    public class AoC2017Day20 : DayBase
    {

        public override string Part1(string input, object args)
        {
            Particle._id = 0;
            var particles = input.Lines().Select(x => Particle.Parse(x)).ToList();
            for (var time = 0; time < 1000; time++)
            {
                particles.ForEach(p => p.Move());
            }
            return particles.Where(x => x.GetDistance() == particles.Min(y => y.GetDistance())).First().Id.ToString();
        }

        public override string Part2(string input, object args)
        {
            var particles = input.Lines().Select(x => Particle.Parse(x)).ToList();
            for (var time = 0; time < 1000; time++)
            {
                particles.ForEach(p => p.Move());
                foreach (var particle in particles)
                {
                    var collisionParticles = particles.Where(x => x.Position.X == particle.Position.X &&
                                                 x.Position.Y == particle.Position.Y &&
                                                 x.Position.Z == particle.Position.Z)
                            .ToList();

                    if (collisionParticles.Count > 1)
                        collisionParticles.ForEach(part => particles.Where(x => x.Id == part.Id).ToList().ForEach(x => x.MarkForDeletion = true));
                }
                particles.RemoveAll(x => x.MarkForDeletion == true);
            }
            return particles.Count.ToString();
        }
    }

    public class Particle
    {
        public static int _id = 0;
        public int Id { get; private set; }
        public bool MarkForDeletion { get; set; }
        public ZPoint Position { get; set; }
        public ZPoint Velocity { get; set; }
        public ZPoint Acceleration { get; set; }

        public static Particle Parse(string input)
        {
            var m = Regex.Match(input, "p=<(\\s*-*\\d*),(\\s*-*\\d*),(\\s*-*\\d*)>, v=<(\\s*-*\\d*),(\\s*-*\\d*),(\\s*-*\\d*)>, a=<(\\s*-*\\d*),(\\s*-*\\d*),(\\s*-*\\d*)>");
            var p = new Particle
            {
                Position = new ZPoint { X = long.Parse(m.Groups[1].Value), Y = long.Parse(m.Groups[2].Value), Z = long.Parse(m.Groups[3].Value) },
                Velocity = new ZPoint { X = long.Parse(m.Groups[4].Value), Y = long.Parse(m.Groups[5].Value), Z = long.Parse(m.Groups[6].Value) },
                Acceleration = new ZPoint { X = long.Parse(m.Groups[7].Value), Y = long.Parse(m.Groups[8].Value), Z = long.Parse(m.Groups[9].Value) },
                Id = _id
            };
            _id++;
            return p;
        }

        public long GetDistance()
        {
            return Math.Abs(Position.X) + Math.Abs(Position.Y) + Math.Abs(Position.Z);
        }

        public void Move()
        {
            Velocity.X += Acceleration.X;
            Velocity.Y += Acceleration.Y;
            Velocity.Z += Acceleration.Z;
            Position.X += Velocity.X;
            Position.Y += Velocity.Y;
            Position.Z += Velocity.Z;
        }
    }
    public class ZPoint
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
    }
}