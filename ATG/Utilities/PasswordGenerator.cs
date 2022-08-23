using System;
using System.Security.Cryptography;
using System.Text;

namespace ATG.Utilities {

    public class PasswordGenerator {

        /// <summary>
        /// Convenience function for generating a random password without having to 
        /// instantiate and set properties.
        /// </summary>
        /// <param name="inMinLength">Minimum password length</param>
        /// <param name="inMaxLength">Maximum password length</param>
        /// <param name="inMaxSpecialCharsAllowed">Max # of special characters allowed in generated password</param>
        /// <returns>Randomly-generated password.</returns>
        static public string GeneratePassword(
            int inMinLength
          , int inMaxLength
          , int inMaxSpecialCharsAllowed
        ) {
            PasswordGenerator pwdGen = new PasswordGenerator();
            pwdGen.MinLength = inMinLength;
            pwdGen.MaxLength = inMaxLength;
            pwdGen.MaxSpecialCharsAllowed = inMaxSpecialCharsAllowed;
            return pwdGen.Generate();
        }
 
        /// <summary>
        /// Default constructor
        /// </summary>
        public PasswordGenerator() {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="inMinLength">Minimum password length</param>
        /// <param name="inMaxLength">Maximum password length</param>
        /// <param name="inMaxSpecialCharsAllowed">Max # of special characters allowed in generated password</param>
        public PasswordGenerator(
            int inMinLength
          , int inMaxLength
          , int inMaxSpecialCharsAllowed
        ) {
            this.MinLength = inMinLength;
            this.MaxLength = inMaxLength;
            this.MaxSpecialCharsAllowed = inMaxSpecialCharsAllowed;
        }

        /// <summary>
        /// Generate a randome # between a lower and upper boundary
        /// </summary>
        /// <param name="inLowerBound">Lower boundary</param>
        /// <param name="inUpperBound">Upper boundary</param>
        /// <returns>An int >= inLowerBound and < inUpperBound</returns>
        protected int GetCryptographicRandomNumber(int inLowerBound, int inUpperBound) {
            if (inLowerBound < 0
                || inLowerBound >= inUpperBound
            ) {
                throw new ArgumentOutOfRangeException("inLowerBound", "Lower boundary must be greater than 0 and less than upper boundry");
            }

            uint urndnum;
            byte[] rndnum = new Byte[4];
            if (inLowerBound == inUpperBound - 1) {
                // test for degenerate case where only lBound can be returned
                return inLowerBound;
            }

            uint xcludeRndBase = (uint.MaxValue -
                (uint.MaxValue % (uint)(inUpperBound - inLowerBound)));
            
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            do {
                rng.GetBytes(rndnum);
                urndnum = System.BitConverter.ToUInt32(rndnum, 0);
            } while (urndnum >= xcludeRndBase);

            return (int)(urndnum % (inUpperBound - inLowerBound)) + inLowerBound;
        }

        /// <summary>
        /// Generate a random character using the characters from passwordChars.
        /// </summary>
        /// <returns>A random character from passwordChars</returns>
        protected char GetRandomCharacter() {
            return passwordChars[GetCryptographicRandomNumber(0, passwordChars.Length - 1)];
        }

        /// <summary>
        /// Generate a random password
        /// </summary>
        /// <returns>A random password</returns>
        public string Generate() {
            // Pick random length between minimum and maximum lengths
            int pwdLength = GetCryptographicRandomNumber(this.MinLength, this.MaxLength);

            StringBuilder pwdBuffer = new StringBuilder();
            pwdBuffer.Capacity = this.MaxLength;
            char nextCharacter;
            int specialCharCount = 0;

            for (int i = 0; i < pwdLength; i++) {
                nextCharacter = GetRandomCharacter();

                // prevent too many special chars
                if (specialChars.IndexOf(nextCharacter) > -1) {
                    specialCharCount++;
                    while ((specialCharCount > MaxSpecialCharsAllowed)
                            && (specialChars.IndexOf(nextCharacter) > -1)
                    ) {
                        nextCharacter = GetRandomCharacter();
                    }
                }

                pwdBuffer.Append(nextCharacter);
            }

            if (null != pwdBuffer) {
                return pwdBuffer.ToString();
            }
            else {
                return String.Empty;
            }
        }

        /// <summary>
        /// Minimum password length
        /// </summary>
        public int MinLength {
            get { return this.minLength; }
            set {
                if (value <= 0 || value > maxLength) {
                    throw new ArgumentOutOfRangeException("MinLength", "Minimum password length must be greater than 0 and less than the maximum length.");
                }
                this.minLength = value;
            }
        }

        /// <summary>
        /// Maximum password length
        /// </summary>
        public int MaxLength {
            get { return this.maxLength; }
            set {
                if (value < minLength) {
                    throw new ArgumentOutOfRangeException("MaxLength", "Maximum password length must be greater than or equal to the minimum length.");
                }
                this.maxLength = value;
            }
        }

        /// <summary>
        /// Maximum # of special characters allowed in a generated password
        /// </summary>
        public int MaxSpecialCharsAllowed {
            get { return this.maxSpecialCharsAllowed; }
            set { this.maxSpecialCharsAllowed = value; }
        }

        private int minLength = 7;
        private int maxLength = 10;
        private int maxSpecialCharsAllowed = 2;
        private const string specialChars = "~!@#$%^&*()-_=+";
        private const string passwordChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" + specialChars;
    }
}
