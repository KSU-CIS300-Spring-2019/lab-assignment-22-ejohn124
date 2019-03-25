/*TrieWithOneChild.cs
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
    /// Class that creates trie with only one child
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Bool indicating if the root of trie is empty
        /// </summary>
        private bool _emptyString;
        /// <summary>
        /// The child of the trie
        /// </summary>
        private ITrie _child;
        /// <summary>
        /// The data of the current root
        /// </summary>
        private char _label;

        /// <summary>
        /// Constructor for our trie
        /// </summary>
        /// <param name="s">string we creating trie with</param>
        /// <param name="empty">bool indicating if the trie is empty</param>
        public TrieWithOneChild(string s, bool empty)
        {
            if(s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _emptyString = empty;
            _label = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }
        /// <summary>
        /// Add a string to our trie
        /// </summary>
        /// <param name="s">string we are adding to trie</param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if(s == "")
            {
                _emptyString = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            
            if(s[0] == _label)
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _emptyString, _label, _child);
            }
        }

        /// <summary>
        /// Checks if trie contains a string, if the string is empty return _emptyString
        /// else we are going to call contains on the _child
        /// </summary>
        /// <param name="s">string we are checking our trie contains</param>
        /// <returns>A bool telling use whether our trie contains a given string</returns>
        public bool Contains(string s)
        {
            if(s == "")
            {
                return _emptyString;
            }
            if(s[0] == _label)
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
