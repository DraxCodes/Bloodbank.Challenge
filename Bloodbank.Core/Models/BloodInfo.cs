
using System;

namespace Bloodbank.Core.Models
{
    public class BloodInfo
    {
        public BloodType BloodType { get; set; }
        public bool IsUniversalRedCellDonor => BloodType == BloodType.ONegative;
        public bool IsUniversalPlasmaDonor => BloodType is BloodType.ABNegative || BloodType is BloodType.ABPositive;
    }
}
