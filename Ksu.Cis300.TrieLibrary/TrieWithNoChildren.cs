/*TrieWithNoChildren.cs
 * Author: Emma Johnson
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// Creates trie with no children
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Bool indicating if the given string is an empty string
        /// </summary>
        private bool _emptyStringContained = false;

        /// <summary>
        /// Adds string, if empty set _emptyString to true, else create
        /// a new TrieWithOneChild
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if(s == "")
            {
                _emptyStringContained = true;
            }

            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                return new TrieWithOneChild(s, _emptyStringContained);
            }
            return this;
        }

        /// <summary>
        /// Checks to see if trie contains string, if it is empty return the value
        /// of _emptyString, else return false.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if(s == "")
            {
                return _emptyStringContained;
            }
            return false;
        }
    }
}
