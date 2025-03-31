using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterations
{
    public class IdentifiableObject
    {
        protected List<string> identifiers;

        protected IdentifiableObject(string[] idList)
        {
            identifiers = new List<string>(idList.Select(id => id.ToLower()));
        }

        public bool AreYou(string id)
        {
            return identifiers.Contains(id.ToLower());
        }

        public string FirstID()
        {
            return identifiers.Count > 0 ? identifiers[0] : "";
        }

        public void AddIdentifier(string id)
        {
            if (!identifiers.Contains(id.ToLower()))
            {
                identifiers.Add(id.ToLower());
            }
        }

        public void ReplaceFirstID(string newID)
        {
            if (identifiers.Count > 0)
            {
                identifiers[0] = newID.ToLower();
            }
            else
            {
                identifiers.Add(newID.ToLower());
            }
        }
    }

}

