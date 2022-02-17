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
        private int currentRankIndex;
        private static int progressLimit = 100;

        public int rank { get; private set; }
        public int progress { get; private set; }

        public User()
        {
            this.currentRankIndex = 0;
            this.rank = rankArray[currentRankIndex];
            this.progress = 0;
        }

        protected User(int rank, int progress)
        {
            this.currentRankIndex = FindIndex(rank);
            this.rank = rank;
            this.progress = progress;
        }

        public void incProgress(int activityRank)
        {
            if (!IsValidRank(activityRank)) throw new ArgumentException("Activity rank doesn't exist");

            int differenceInRankings = FindIndex(activityRank) - this.currentRankIndex;

            if (differenceInRankings < -1) return;

            int progressToReceive = 0;
            switch(differenceInRankings)
            {
                case (-1):
                    progressToReceive = 1;
                    break;
                case (0):
                    progressToReceive = 3;
                    break;
                default:
                    progressToReceive = 10 * differenceInRankings * differenceInRankings;
                    break;
            }

            this.progress += progressToReceive;
            TryRankUp();
        }

        private void TryRankUp()
        {
            while(this.progress>=progressLimit)
            {
                if (this.currentRankIndex == rankArray.Length - 1) return;
                this.progress -= progressLimit;
                this.currentRankIndex++;
                this.rank = rankArray[this.currentRankIndex];
            }
        }

        private int FindIndex(int rank)
        {
            int index = -1;

            for (int i = 0; i < rankArray.Length; i++)
                if (rankArray[i] == rank) return i;

            return index;
        }

        private bool IsValidRank(int activityRank)
        {
            return (activityRank != 0 && activityRank >= rankArray[0] && activityRank <= rankArray[rankArray.Length - 1]);
        }
    }
}
