using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace zi_rgr
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            generateIV();
        }
        byte[] sBox = new byte[256]
         {
            0x63, 0x7C, 0x77, 0x7B, 0xF2, 0x6B, 0x6F, 0xC5, 0x30, 0x01, 0x67, 0x2B, 0xFE, 0xD7, 0xAB, 0x76,
            0xCA, 0x82, 0xC9, 0x7D, 0xFA, 0x59, 0x47, 0xF0, 0xAD, 0xD4, 0xA2, 0xAF, 0x9C, 0xA4, 0x72, 0xC0,
            0xB7, 0xFD, 0x93, 0x26, 0x36, 0x3F, 0xF7, 0xCC, 0x34, 0xA5, 0xE5, 0xF1, 0x71, 0xD8, 0x31, 0x15,
            0x04, 0xC7, 0x23, 0xC3, 0x18, 0x96, 0x05, 0x9A, 0x07, 0x12, 0x80, 0xE2, 0xEB, 0x27, 0xB2, 0x75,
            0x09, 0x83, 0x2C, 0x1A, 0x1B, 0x6E, 0x5A, 0xA0, 0x52, 0x3B, 0xD6, 0xB3, 0x29, 0xE3, 0x2F, 0x84,
            0x53, 0xD1, 0x00, 0xED, 0x20, 0xFC, 0xB1, 0x5B, 0x6A, 0xCB, 0xBE, 0x39, 0x4A, 0x4C, 0x58, 0xCF,
            0xD0, 0xEF, 0xAA, 0xFB, 0x43, 0x4D, 0x33, 0x85, 0x45, 0xF9, 0x02, 0x7F, 0x50, 0x3C, 0x9F, 0xA8,
            0x51, 0xA3, 0x40, 0x8F, 0x92, 0x9D, 0x38, 0xF5, 0xBC, 0xB6, 0xDA, 0x21, 0x10, 0xFF, 0xF3, 0xD2,
            0xCD, 0x0C, 0x13, 0xEC, 0x5F, 0x97, 0x44, 0x17, 0xC4, 0xA7, 0x7E, 0x3D, 0x64, 0x5D, 0x19, 0x73,
            0x60, 0x81, 0x4F, 0xDC, 0x22, 0x2A, 0x90, 0x88, 0x46, 0xEE, 0xB8, 0x14, 0xDE, 0x5E, 0x0B, 0xDB,
            0xE0, 0x32, 0x3A, 0x0A, 0x49, 0x06, 0x24, 0x5C, 0xC2, 0xD3, 0xAC, 0x62, 0x91, 0x95, 0xE4, 0x79,
            0xE7, 0xC8, 0x37, 0x6D, 0x8D, 0xD5, 0x4E, 0xA9, 0x6C, 0x56, 0xF4, 0xEA, 0x65, 0x7A, 0xAE, 0x08,
            0xBA, 0x78, 0x25, 0x2E, 0x1C, 0xA6, 0xB4, 0xC6, 0xE8, 0xDD, 0x74, 0x1F, 0x4B, 0xBD, 0x8B, 0x8A,
            0x70, 0x3E, 0xB5, 0x66, 0x48, 0x03, 0xF6, 0x0E, 0x61, 0x35, 0x57, 0xB9, 0x86, 0xC1, 0x1D, 0x9E,
            0xE1, 0xF8, 0x98, 0x11, 0x69, 0xD9, 0x8E, 0x94, 0x9B, 0x1E, 0x87, 0xE9, 0xCE, 0x55, 0x28, 0xDF,
            0x8C, 0xA1, 0x89, 0x0D, 0xBF, 0xE6, 0x42, 0x68, 0x41, 0x99, 0x2D, 0x0F, 0xB0, 0x54, 0xBB, 0x16
         };
        byte[] invSBox = new byte[256]
         {
            0x52, 0x09, 0x6A, 0xD5, 0x30, 0x36, 0xA5, 0x38, 0xBF, 0x40, 0xA3, 0x9E, 0x81, 0xF3, 0xD7, 0xFB,
            0x7C, 0xE3, 0x39, 0x82, 0x9B, 0x2F, 0xFF, 0x87, 0x34, 0x8E, 0x43, 0x44, 0xC4, 0xDE, 0xE9, 0xCB,
            0x54, 0x7B, 0x94, 0x32, 0xA6, 0xC2, 0x23, 0x3D, 0xEE, 0x4C, 0x95, 0x0B, 0x42, 0xFA, 0xC3, 0x4E,
            0x08, 0x2E, 0xA1, 0x66, 0x28, 0xD9, 0x24, 0xB2, 0x76, 0x5B, 0xA2, 0x49, 0x6D, 0x8B, 0xD1, 0x25,
            0x72, 0xF8, 0xF6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xD4, 0xA4, 0x5C, 0xCC, 0x5D, 0x65, 0xB6, 0x92,
            0x6C, 0x70, 0x48, 0x50, 0xFD, 0xED, 0xB9, 0xDA, 0x5E, 0x15, 0x46, 0x57, 0xA7, 0x8D, 0x9D, 0x84,
            0x90, 0xD8, 0xAB, 0x00, 0x8C, 0xBC, 0xD3, 0x0A, 0xF7, 0xE4, 0x58, 0x05, 0xB8, 0xB3, 0x45, 0x06,
            0xD0, 0x2C, 0x1E, 0x8F, 0xCA, 0x3F, 0x0F, 0x02, 0xC1, 0xAF, 0xBD, 0x03, 0x01, 0x13, 0x8A, 0x6B,
            0x3A, 0x91, 0x11, 0x41, 0x4F, 0x67, 0xDC, 0xEA, 0x97, 0xF2, 0xCF, 0xCE, 0xF0, 0xB4, 0xE6, 0x73,
            0x96, 0xAC, 0x74, 0x22, 0xE7, 0xAD, 0x35, 0x85, 0xE2, 0xF9, 0x37, 0xE8, 0x1C, 0x75, 0xDF, 0x6E,
            0x47, 0xF1, 0x1A, 0x71, 0x1D, 0x29, 0xC5, 0x89, 0x6F, 0xB7, 0x62, 0x0E, 0xAA, 0x18, 0xBE, 0x1B,
            0xFC, 0x56, 0x3E, 0x4B, 0xC6, 0xD2, 0x79, 0x20, 0x9A, 0xDB, 0xC0, 0xFE, 0x78, 0xCD, 0x5A, 0xF4,
            0x1F, 0xDD, 0xA8, 0x33, 0x88, 0x07, 0xC7, 0x31, 0xB1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xEC, 0x5F,
            0x60, 0x51, 0x7F, 0xA9, 0x19, 0xB5, 0x4A, 0x0D, 0x2D, 0xE5, 0x7A, 0x9F, 0x93, 0xC9, 0x9C, 0xEF,
            0xA0, 0xE0, 0x3B, 0x4D, 0xAE, 0x2A, 0xF5, 0xB0, 0xC8, 0xEB, 0xBB, 0x3C, 0x83, 0x53, 0x99, 0x61,
            0x17, 0x2B, 0x04, 0x7E, 0xBA, 0x77, 0xD6, 0x26, 0xE1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0C, 0x7D
         };
        byte[] Rcon = new byte[255]{
            0x8d, 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8,
            0xab, 0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3,
            0x7d, 0xfa, 0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f,
            0x25, 0x4a, 0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d,
            0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab,
            0x4d, 0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d,
            0xfa, 0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25,
            0x4a, 0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d, 0x01,
            0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d,
            0x9a, 0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa,
            0xef, 0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a,
            0x94, 0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d, 0x01, 0x02,
            0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a,
            0x2f, 0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef,
            0xc5, 0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94,
            0x33, 0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb, 0x8d, 0x01, 0x02, 0x04,
            0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36, 0x6c, 0xd8, 0xab, 0x4d, 0x9a, 0x2f,
            0x5e, 0xbc, 0x63, 0xc6, 0x97, 0x35, 0x6a, 0xd4, 0xb3, 0x7d, 0xfa, 0xef, 0xc5,
            0x91, 0x39, 0x72, 0xe4, 0xd3, 0xbd, 0x61, 0xc2, 0x9f, 0x25, 0x4a, 0x94, 0x33,
            0x66, 0xcc, 0x83, 0x1d, 0x3a, 0x74, 0xe8, 0xcb
        };
        int Nr = 10;
        byte[,] keySchedule;
        bool fileSelected = false;
        bool isCBC = false;
        void keyExpand()
        {
            keySchedule = new byte[4, (Nr + 1) * 4];

            PasswordDeriveBytes cdk = new PasswordDeriveBytes(tbPassword.Text, null);

            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] key = cdk.CryptDeriveKey("RC2", "SHA1", 128, iv);

            int length = 4;
            int k = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    keySchedule[i, j] = key[k++];
                }
            }

            for (int col = 4; col < (Nr + 1) * 4; col++)
            {
                if (col % 4 == 0)
                {
                    keySchedule[0, col] = keySchedule[1, col - 1];
                    keySchedule[1, col] = keySchedule[2, col - 1];
                    keySchedule[2, col] = keySchedule[3, col - 1];
                    keySchedule[3, col] = keySchedule[0, col - 1];

                    keySchedule[0, col] = sBox[keySchedule[0, col]];
                    keySchedule[1, col] = sBox[keySchedule[1, col]];
                    keySchedule[2, col] = sBox[keySchedule[2, col]];
                    keySchedule[3, col] = sBox[keySchedule[3, col]];

                    keySchedule[0, col] = (byte)(keySchedule[0, col] ^ keySchedule[0, col - 4] ^ Rcon[col / 4]);
                    keySchedule[1, col] = (byte)(keySchedule[1, col] ^ keySchedule[1, col - 4] ^ 0);
                    keySchedule[2, col] = (byte)(keySchedule[2, col] ^ keySchedule[2, col - 4] ^ 0);
                    keySchedule[3, col] = (byte)(keySchedule[3, col] ^ keySchedule[3, col - 4] ^ 0);
                }
                else
                {
                    keySchedule[0, col] = (byte)(keySchedule[0, col - 1] ^ keySchedule[0, col - 4]);
                    keySchedule[1, col] = (byte)(keySchedule[1, col - 1] ^ keySchedule[1, col - 4]);
                    keySchedule[2, col] = (byte)(keySchedule[2, col - 1] ^ keySchedule[2, col - 4]);
                    keySchedule[3, col] = (byte)(keySchedule[3, col - 1] ^ keySchedule[3, col - 4]);
                }
            }

        }
        void addRoundKey(byte[] state, int round)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i * 4 + j] = (byte)(state[i * 4 + j] ^ keySchedule[i, j + round * 4]);
                }
            }
        }
        void subBytes(byte[] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                state[i] = sBox[state[i]];
            }
        }
        void invSubBytes(byte[] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                state[i] = invSBox[state[i]];
            }
        }
        void shfitRows(byte[] state)
        {
            byte buf1, buf2;
            buf1 = state[4];
            state[4] = state[5];
            state[5] = state[6];
            state[6] = state[7];
            state[7] = buf1;

            buf1 = state[8];
            buf2 = state[9];
            state[8] = state[10];
            state[9] = state[11];
            state[10] = buf1;
            state[11] = buf2;

            buf1 = state[15];
            state[15] = state[14];
            state[14] = state[13];
            state[13] = state[12];
            state[12] = buf1;
        }
        void invShfitRows(byte[] state)
        {
            byte buf1, buf2;
            buf1 = state[7];
            state[7] = state[6];
            state[6] = state[5];
            state[5] = state[4];
            state[4] = buf1;

            buf1 = state[8];
            buf2 = state[9];
            state[8] = state[10];
            state[9] = state[11];
            state[10] = buf1;
            state[11] = buf2;

            buf1 = state[12];
            state[12] = state[13];
            state[13] = state[14];
            state[14] = state[15];
            state[15] = buf1;
        }
        void invMixColumns(byte[] state)
        {
            byte[] temp = new byte[16];
            for (int i = 0; i < 16; ++i)
            {
                temp[i] = state[i];
            }

            for (int c = 0; c < 4; ++c)
            {
                state[0 + c]  = (byte)( (int)gfmultby0e(temp[0 + c]) ^ (int)gfmultby0b(temp[4 + c]) ^
                                        (int)gfmultby0d(temp[8 + c]) ^ (int)gfmultby09(temp[12 + c]));

                state[4 + c]  = (byte)( (int)gfmultby09(temp[0 + c]) ^ (int)gfmultby0e(temp[4 + c]) ^
                                        (int)gfmultby0b(temp[8 + c]) ^ (int)gfmultby0d(temp[12 + c]));

                state[8 + c]  = (byte)( (int)gfmultby0d(temp[0 + c]) ^ (int)gfmultby09(temp[4 + c]) ^
                                        (int)gfmultby0e(temp[8 + c]) ^ (int)gfmultby0b(temp[12 + c]));

                state[12 + c] = (byte)( (int)gfmultby0b(temp[0 + c]) ^ (int)gfmultby0d(temp[4 + c]) ^
                                        (int)gfmultby09(temp[8 + c]) ^ (int)gfmultby0e(temp[12 + c]));
            }
        }
        void mixColumns(byte[] state)
        {
            byte[] temp = new byte[16];
            for (int i = 0; i < 16; ++i)
            {
                temp[i] = state[i];
            }

            for (int c = 0; c < 4; ++c)
            {
                
                state[0 + c]  = (byte)((int)gfmultby02(temp[0 + c]) ^ (int)gfmultby03(temp[4 + c]) ^
                                       (int)gfmultby01(temp[8 + c]) ^ (int)gfmultby01(temp[12 + c]));

                state[4 + c]  = (byte)((int)gfmultby01(temp[0 + c]) ^ (int)gfmultby02(temp[4 + c]) ^
                                       (int)gfmultby03(temp[8 + c]) ^ (int)gfmultby01(temp[12 + c]));

                state[8 + c]  = (byte)((int)gfmultby01(temp[0 + c]) ^ (int)gfmultby01(temp[4 + c]) ^
                                       (int)gfmultby02(temp[8 + c]) ^ (int)gfmultby03(temp[12 + c]));

                state[12 + c] = (byte)((int)gfmultby03(temp[0 + c]) ^ (int)gfmultby01(temp[4 + c]) ^
                                       (int)gfmultby01(temp[8 + c]) ^ (int)gfmultby02(temp[12 + c]));
            }
        }
        private static byte gfmultby01(byte b)
        {
            return b;
        }

        byte gfmultby02(byte b)
        {
            if (b < 0x80)
                return (byte)(int)(b << 1);
            else
                return (byte)((int)(b << 1) ^ (int)(0x1b));
        }

        byte gfmultby03(byte b)
        {
            return (byte)((int)gfmultby02(b) ^ (int)b);
        }

        byte gfmultby09(byte b)
        {
            return (byte)((int)gfmultby02(gfmultby02(gfmultby02(b))) ^
                           (int)b);
        }

        byte gfmultby0b(byte b)
        {
            return (byte)((int)gfmultby02(gfmultby02(gfmultby02(b))) ^
                           (int)gfmultby02(b) ^
                           (int)b);
        }

        byte gfmultby0d(byte b)
        {
            return (byte)((int)gfmultby02(gfmultby02(gfmultby02(b))) ^
                           (int)gfmultby02(gfmultby02(b)) ^
                           (int)(b));
        }

        byte gfmultby0e(byte b)
        {
            return (byte)((int)gfmultby02(gfmultby02(gfmultby02(b))) ^
                           (int)gfmultby02(gfmultby02(b)) ^
                           (int)gfmultby02(b));
        }

        void printDecrypted(byte[] output, int zeroCharsCount)
        {
            zeroCharsCount = zeroCharsCount < 0 ? 0 : zeroCharsCount > 15 ? 15 : zeroCharsCount;
            string str = Encoding.UTF8.GetString(output);
            tbOutput.Text = zeroCharsCount == 0 ? str : str.Remove(str.Length - zeroCharsCount);
            return;
        }

        void printEncrypted(byte[] output)
        {
            tbOutput.Text = 
                cbOutputToBase64.Checked ? 
                Convert.ToBase64String(output) : 
                BitConverter.ToString(output);        
        }

        void encryptAES(byte[] state)
        {
            byte[] temp = new byte[16];
            for (int i = 0; i < 16; i++) { temp[i] = state[i]; }
            for (int col = 0; col < state.Length / 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    state[row + col * 4] = temp[row * 4 + col];
                }
            }
            addRoundKey(state, 0);

            for (int i = 1; i < Nr; i++)
            {
                subBytes(state);
                shfitRows(state);
                mixColumns(state);
                addRoundKey(state, i);
            }

            subBytes(state);
            shfitRows(state);
            addRoundKey(state, Nr);

        }
        void decryptAES(byte[] state)
        {
            addRoundKey(state, Nr);

            for (int round = Nr - 1; round > 0; round--)
            {
                invShfitRows(state);
                invSubBytes(state);
                addRoundKey(state, round);
                invMixColumns(state);
            }

            invShfitRows(state);
            invSubBytes(state);
            addRoundKey(state, 0);

            byte[] temp = new byte[16];
            for (int i = 0; i < 16; i++) { temp[i] = state[i];  }
            for (int col = 0; col < state.Length / 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    state[row + col * 4] = temp[row * 4 + col];
                }
            }
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            tbOutput.Clear();
            keyExpand();

            byte[] text = Encoding.UTF8.GetBytes(tbInput.Text);

            int addedZerosCount = text.Length % 16 == 0 ? 0 : 16 - text.Length % 16;
            Debug.Assert((text.Length + addedZerosCount) % 16 == 0);

            byte[] sizeBlock = new byte[16];            
            byte[] textZeros = new byte[addedZerosCount];
            Array.Clear(textZeros, 0, addedZerosCount);
            Array.Clear(sizeBlock, 0, 16);
            sizeBlock[0] = (byte)addedZerosCount;

            List<byte> list = new List<byte>();
            list.AddRange(sizeBlock);
            list.AddRange(text);
            list.AddRange(textZeros);
            byte[] input = list.ToArray();
            Debug.Assert(input.Length % 16 == 0);

            byte[] encrypted = encrypt(input);

            printEncrypted(encrypted);
        }
        byte[] xorArrays(byte[] a1, byte[] a2)
        {
            Debug.Assert(a1.Length == a2.Length);
            byte[] result = new byte[a1.Length];
            for (int i = 0; i < a1.Length; i++)
            {
                result[i] = (byte)(a1[i] ^ a2[i]);
            }
            return result;
        }
        byte[] encrypt(byte[] input)
        {
            byte[] state = new byte[16];
            List<byte> output = new List<byte>();
            int inputLength = input.Length;
            int j = 0;
            byte[] IV = null;
            if (isCBC)
            {
                IV = new byte[16];
                IV = Convert.FromBase64String(tbIV.Text);
            }
            for (int i = 0; i < inputLength; i++)
            {
                state[j] = input[i];

                if (j == 15)
                {
                    j = 0;
                    if (isCBC) state = xorArrays(state, IV);
                    encryptAES(state);
                    if (isCBC) Array.Copy(state, IV, 16);
                    output.AddRange(state);
                    Application.DoEvents();
                    continue;
                }
                j++;
            }
            Debug.Assert(j == 0);
            return output.ToArray();
        } 
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (tbInput.Text.Length == 0) return;
            byte[] input = null;
            try
            {
                input = Convert.FromBase64String(tbInput.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Строка должна быть в формате Base64", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            if (input.Length % 16 != 0 || input.Length < 16)
            {
                MessageBox.Show("Строка должна быть в формате Base64", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tbOutput.Clear();
            keyExpand();

            byte[] output = decrypt(input);

            byte[] sizeBlock = new byte[16];
            Array.Copy(output, 0, sizeBlock, 0, 16);
            int zeroCount = sizeBlock[0];

            byte[] outputWithoutSizeBlock = new byte[output.Length - 16];
            Array.Copy(output, 16, outputWithoutSizeBlock, 0, output.Length - 16);
           
            printDecrypted(outputWithoutSizeBlock, zeroCount);
        }

        byte[] decrypt(byte[] input)
        {
            byte[] state = new byte[16];
            List<byte> output = new List<byte>();
            int inputLength = input.Length;
            int j = 0;
            byte[] IV = null;
            byte[] tempIV = null;
            if (isCBC)
            {
                IV = new byte[16];
                tempIV = new byte[16];
                IV = Convert.FromBase64String(tbIV.Text);
                Debug.WriteLine(BitConverter.ToString(IV));
            }
            for (int i = 0; i < inputLength; i++)
            {
                state[j] = input[i];

                if (j == 15)
                {
                    j = 0;
                    if (isCBC) Array.Copy(state, tempIV, 16);
                    decryptAES(state);
                    if (isCBC) state = xorArrays(state, IV);
                    if (isCBC) Array.Copy(tempIV, IV, 16);
                    output.AddRange(state);
                    Application.DoEvents();
                    continue;
                }
                j++;
            }
            Debug.Assert(j == 0);
            return output.ToArray();
        }

        private void btnCopyToInput_Click(object sender, EventArgs e)
        {
            tbInput.Text = tbOutput.Text;
        }


        private void btnEncryptFile_Click(object sender, EventArgs e)
        {
            ofdEncryptFile.ShowDialog();
            if (fileSelected)
            {
                Enabled = false;
                Text = "РГР Защита информации, реализация алгоритма AES" + " [Шифрование...]";
                encryptFile();
                Enabled = true;
                Text = "РГР Защита информации, реализация алгоритма AES";
            }
            fileSelected = false;
        }

        private void ofdEncryptFile_FileOk(object sender, CancelEventArgs e)
        {
            fileSelected = true;
        }
        void encryptFile()
        {
            tbInput.Text = ofdEncryptFile.FileName;

            tbOutput.Clear();
            keyExpand();

            byte[] data = File.ReadAllBytes(ofdEncryptFile.FileName);

            int addedZerosCount = data.Length % 16 == 0 ? 0 : 16 - data.Length % 16;
            Debug.Assert((data.Length + addedZerosCount) % 16 == 0);

            byte[] sizeBlock = new byte[16];
            byte[] textZeros = new byte[addedZerosCount];
            Array.Clear(textZeros, 0, addedZerosCount);
            Array.Clear(sizeBlock, 0, 16);
            sizeBlock[0] = (byte)addedZerosCount;

            List<byte> list = new List<byte>();
            list.AddRange(sizeBlock);
            list.AddRange(data);
            list.AddRange(textZeros);
            byte[] input = list.ToArray();
            Debug.Assert(input.Length % 16 == 0);

            byte[] encrypted = encrypt(input);

            string encryptedFileName = Path.Combine(
                Path.GetDirectoryName(ofdEncryptFile.FileName),
                ("AES-encrypted." + Path.GetFileName(ofdEncryptFile.FileName))
            );

            File.WriteAllBytes(encryptedFileName, encrypted);
            tbOutput.Text = "Зашифрованный файл: " + encryptedFileName;
        }

        private void btnDecryptFile_Click(object sender, EventArgs e)
        {
            ofdDecryptFile.ShowDialog();
            if (fileSelected)
            {
                Enabled = false;
                Text = "РГР Защита информации, реализация алгоритма AES" + " [Дешифрование...]";
                decryptFile();
                Enabled = true;
                Text = "РГР Защита информации, реализация алгоритма AES";
            }
            fileSelected = false;
        }
        private void ofdDecryptFile_FileOk(object sender, CancelEventArgs e)
        {
            fileSelected = true;
        }
        void decryptFile()
        {
            tbInput.Text = ofdDecryptFile.FileName;
            keyExpand();
            byte[] data = File.ReadAllBytes(ofdDecryptFile.FileName);

            byte[] decrypted = decrypt(data);

            byte[] sizeBlock = new byte[16];
            Array.Copy(decrypted, 0, sizeBlock, 0, 16);
            int zeroCount = sizeBlock[0];
            
            byte[] temp = new byte[decrypted.Length - zeroCount - 16];
            Array.Copy(decrypted, 16, temp, 0, decrypted.Length - zeroCount - 16);
            decrypted = temp;
            Debug.WriteLine(zeroCount + " " + decrypted.Length);
            string encryptedFileName = Path.Combine(
                Path.GetDirectoryName(ofdDecryptFile.FileName),
                ( "AES-decrypted." + Path.GetFileName(ofdDecryptFile.FileName).Replace("AES-encrypted.", "") )
            );
            File.WriteAllBytes(encryptedFileName, decrypted);
            tbOutput.Text = "Расшифрованный файл: " + encryptedFileName;
        }

        private void rbModeCBC_CheckedChanged(object sender, EventArgs e)
        {
            lIV.Visible = rbModeCBC.Checked;
            tbIV.Visible = rbModeCBC.Checked;
            btnGenerateIV.Visible = rbModeCBC.Checked;
            isCBC = rbModeCBC.Checked;
        }

        private void btnGenerateIV_Click(object sender, EventArgs e)
        {
            generateIV();
        }
        void generateIV()
        {
            PasswordDeriveBytes cdk = new PasswordDeriveBytes(tbIV.Text, null);

            byte[] iv = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            byte[] key = cdk.CryptDeriveKey("RC2", "SHA1", 128, iv);
            tbIV.Text = Convert.ToBase64String(key);
        }
    }
}
