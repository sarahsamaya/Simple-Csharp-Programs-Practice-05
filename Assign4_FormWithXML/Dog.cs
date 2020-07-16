using System;
using System.Collections.Generic;
using System.Text;

namespace Assign4_FormWithXML
{
    public class Dog
    {
        private string dogName;
        private string dogOwnerName;
        private int dogAge;
        private string dogOwnerPhone;

        public Dog() { }

        public Dog(string dogName, string dogOwnerName, int dogAge, int DogOwnerPhone)
        {
            this.dogName = dogName;
            this.dogOwnerName = dogOwnerName;
            this.dogAge = dogAge;
            this.DogOwnerPhone = dogOwnerPhone;
        }
        public string DogName { 
            get => dogName; 
            set => dogName = value; 
        }
        public string DogOwnerName { 
            get => dogOwnerName; 
            set => dogOwnerName = value; 
        }
        public int DogAge { 
            get => dogAge; 
            set => dogAge = value; 
        }
        public string DogOwnerPhone { 
            get => dogOwnerPhone; 
            set => dogOwnerPhone = value; 
        }

        public override bool Equals(object obj)
        {
            return obj is Dog dog &&
                   DogName == dog.DogName &&
                   DogOwnerName == dog.DogOwnerName &&
                   DogAge == dog.DogAge &&
                   DogOwnerPhone == dog.DogOwnerPhone;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DogName, DogOwnerName, DogAge, DogOwnerPhone);
        }
    }


}
