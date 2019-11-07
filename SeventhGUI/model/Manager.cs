using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeventhGUI.model
{
    class Manager
    {
        private string id;
        private string firstName;
        private string lastName;
        private double winningPercentage;

        public Manager(string id, string firstName, string lastName, uint wins, uint losses)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            if (losses > 0)
            {
                this.winningPercentage = (double)wins / (wins + losses);
            }
            else
            {
                this.winningPercentage = 0;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
        }

        public string WinningPercentage
        {
            get
            {
                return string.Format($"{winningPercentage:f3}");
            }
        }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
