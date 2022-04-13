using System;
using UnityEngine;

namespace Static.Constants
{
    public class Constants : ScriptableObject
    {
        public string GetConstant(ConstantsKeysEnum constantsKey)
        {
            switch (constantsKey)
            {
                case ConstantsKeysEnum.HighScore:
                    return "HighScore";
                default:
                    throw new Exception($"Invalid constant key: {constantsKey}");
            }

        }

    }
}