using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class MessageFilter
    {
        public const int WORD_WHITELIST = 0;
        public const int WORD_BLACKLIST = 1;
        public const int USER_WHITELIST = 2;
        public const int USER_BLACKLIST = 3;

        public List<IFilterComponent> Components { get; set; }

        public MessageFilter()
        {
            Components = new List<IFilterComponent>();
        }

        public IFilterComponent buildComponent(int filterType, List<string> toFilter)
        {
            switch (filterType)
            {
                case WORD_WHITELIST:
                    return new WordWhitelistComponent(toFilter);
                case WORD_BLACKLIST:
                    return new WordBlackListComponent(toFilter);
                case USER_WHITELIST:
                    return new UserWhitelistComponent(toFilter);
                case USER_BLACKLIST:
                    return new UserBlacklistComponent(toFilter);
                default:
                    return null;
            }
        }

        public bool messagePassesFilter(Message message)
        {
            foreach (IFilterComponent comp in Components)
            {
                if (!comp.messagePassesFilter(message)) { return false; }
            }

            return true;
        }
    }
}
