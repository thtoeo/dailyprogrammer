using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Challenge279.Intermediate
{
    public static class Container
    {
        public class Line
        {
            public List<string> Words { get; set; }
            public int Length { get; set; }

            public Line()
            {
                Words = new List<string>();
                Length = 0;
            }

            public Line(string word) : this()
            {
                if (string.IsNullOrEmpty(word))
                {
                    return;
                }

                Words = new List<string> {word};
                Length = word.Length;
            }

            public bool AddWordIfFits(string word, int lineLength)
            {
                if (string.IsNullOrEmpty(word))
                {
                    return true;
                }

                if (Length + word.Length > lineLength)
                {
                    return false;
                }

                AddWord(word);
                return true;
            }

            public void AddWord(string word)
            {
                Words.Add(word);
                Length += word.Length;
            }

            public string ToString(string separator = " ")
            {
                return string.Join(separator, Words);
            }
        }

        public class Paragraph
        {
            public List<string> Words { get; set; }

            public Paragraph()
            {
                Words = new List<string>();
            }

            public Paragraph(string text) : this()
            {
                if (text == null)
                {
                    return;
                }

                text = text.Replace(Environment.NewLine, " ");
                Words = text.Split(' ').ToList();
            }

            public string ToString(int lineWidth)
            {
                var lines = new List<Line>();
                var line = new Line();

                Words.ForEach(word =>
                {
                    if (!line.AddWordIfFits(word, lineWidth))
                    {
                        lines.Add(line);
                        line = new Line(word);
                    }
                });

                if (line.Length > 0)
                {
                    lines.Add(line);
                }

                return string.Join(Environment.NewLine, lines.Select(x => x.ToString()));
            }
        }

        public static string FitToLineWidth(string text, int lineWidth)
        {
            var paragraphs = text
                .Split(new[] {Environment.NewLine + Environment.NewLine}, StringSplitOptions.None)
                .Select(x => new Paragraph(x))
                .ToList();

            return string.Join(Environment.NewLine + Environment.NewLine, paragraphs.Select(x => x.ToString(lineWidth)));
        }
    }
}
