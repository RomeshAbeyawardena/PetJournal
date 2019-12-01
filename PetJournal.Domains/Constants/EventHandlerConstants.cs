using System;
using System.Collections.Generic;
using System.Text;

namespace PetJournal.Domains.Constants
{
    public partial class Constants
    {
        #region EventHandler Commands
        public const string GetPetType = "GetPetType";
        public const string GetPetBreed = "GetPetBreed";
        #endregion

        #region EventHandler Parameters
        public const string PetTypeParameter  = "PetTypeParameter";
        public const string PetTypeBreedParameter = "PetTypeBreedParameter";
        #endregion
    }
}
