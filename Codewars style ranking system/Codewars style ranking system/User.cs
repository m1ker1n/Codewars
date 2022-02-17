using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codewars_style_ranking_system
{
    class User
    {
        private static int[] rankArray =
            {-8,-7,-6,-5,-4,-3,-2,-1,1,2,3,4,5,6,7,8};
        private static int progressLimit = 100;

        public int rank { get; private set; }
        public int progress { get; private set; }

        public User()
        {
            rank = rankArray[0];
            progress = 0;
        }

        protected User(int rank, int progress)
        {
            this.rank = rank;
            this.progress = progress;
        }

        public int incProgress(int activityRank)
        {
            int result = 0;

            return result;
        }
    }
}
