using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MiHs.Common
{
    /// <summary>
    /// String extension methods class, mainly for use with file paths
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Ensures that a path name ends with a trailing backslash
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        public static string EnsureTrailingBackslash(this string pathName)
        {
            return pathName[pathName.Length-1] == '\\' ? pathName : pathName + '\\';
        }

        /// <summary>
        /// Removes the volume letter (and the following ':') at the beginning of a string
        /// </summary>
        /// <param name="pathName"></param>
        /// <returns></returns>
        public static string RemoveVolumeLetter(this string pathName)
        {
            if (!string.IsNullOrEmpty(pathName) && pathName[0] != '\\' && pathName[1]==Path.VolumeSeparatorChar)
            {
                return pathName.Substring(2);
            }
            return pathName;
        }

        /// <summary>
        /// Returns true if the filename matches a given pattern
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool MatchesFilePattern(this string fileName, string pattern)
        {
            if (pattern == "*" || pattern == "*.*") return true;

            Regex regex = FindFilesPatternToRegex.Convert(pattern);
            return regex.IsMatch(fileName);
        }

        /// <summary>
        /// Converts a filename pattern to a regular expression
        /// </summary>
        /// <remarks>Quoted from answer at https://stackoverflow.com/questions/652037/how-do-i-check-if-a-filename-matches-a-wildcard-pattern
        /// </remarks>
        internal static class FindFilesPatternToRegex
        {
            private static readonly char[] illegalChars = (@"\/:<>|" + "\"").ToCharArray();
            //private static Regex IllegalCharactersRegex = new Regex("[" + @"\/:<>|" + "\"]", RegexOptions.Compiled);
            private static Regex CatchExtensionRegex = new Regex(@"^\s*.+\.([^\.]+)\s*$", RegexOptions.Compiled);
            private static Regex HasQuestionMarkRegEx = new Regex(@"\?", RegexOptions.Compiled);

            private static string NonDotCharacters = @"[^.]*";

            public static Regex Convert(string pattern)
            {
                pattern = checkPattern(pattern);

                bool hasExtension = CatchExtensionRegex.IsMatch(pattern);

                bool matchExact = false;
                if (HasQuestionMarkRegEx.IsMatch(pattern))
                {
                    matchExact = true;
                }
                else if (hasExtension)
                {
                    matchExact = CatchExtensionRegex.Match(pattern).Groups[1].Length != 3;
                }

                string regexString = Regex.Escape(pattern);
                regexString = "^" + Regex.Replace(regexString, @"\\\*", ".*");
                regexString = Regex.Replace(regexString, @"\\\?", ".");

                if (!matchExact && hasExtension)
                {
                    regexString += NonDotCharacters;
                }

                regexString += "$";

                Regex regex = new Regex(regexString, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                return regex;
            }

            private static string checkPattern(string pattern)
            {
                if (pattern == null)
                {
                    throw new ArgumentNullException();
                }
                pattern = pattern.Trim();
                if (pattern.Length == 0)
                {
                    throw new ArgumentException("Pattern is empty.");
                }

                if (pattern.IndexOfAny(illegalChars) >= 0)
                //if (IllegalCharactersRegex.IsMatch(pattern))
                {
                    throw new ArgumentException("Pattern contains illegal characters.");
                }

                return pattern;
            }
        }
    }
}
