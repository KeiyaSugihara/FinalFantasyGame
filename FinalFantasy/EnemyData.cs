using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy
{
    class EnemyData 
    {

        #region Field
        private const int PowerLevel = 3;
        private const int DefenseLevel = 2;
        public string CharacterName { get; set; }
        public int CharacterId { get; set; }
        public string Gender { get; set; }
        public string Deathblow1 { get; set; }
        public string Deathblow2 { get; set; }
        public string Deathblow3 { get; set; }
        public int HitPoint { get; set; }
        public int NowHitPoint { get; set; }
        public int MagicPoint { get; set; }
        public string Status { get; set; }
        public int NowLevel { get; set; }
        public int ObtainExperiencePoint { get; set; }
        public string ImagPass { get; set; }
        public string EffectPass1 { get; set; }
        public string EffectPass2 { get; set; }
        public string EffectPass3 { get; set; }
        public string EncounterPass { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ―
        /// </summary>
        /// <param name="cstCharacterName">名前</param>
        /// <param name="cstGender">性別</param>          
        /// <param name="cstDeathblow">得意技</param>
        /// <param name="cstHitPoint">HP</param>
        /// <param name="cstMagicPoint">MP</param>
        /// <param name="cstStatus">状態</param>
        public EnemyData(int cstCharacterId, int cstLevel, int cstObtainExperiencePoint, string cstCharacterName, string cstGender,
                             string cstDeathblow1, string cstDeathblow2,
                             string cstDeathblow3, int cstHitPoint,
                             int cstMagicPoint, string cstStatus, string cstImagPass,
                             string csteffectPass1, string csteffectPass2, string csteffectPass3, string cstencounterPass)
        {
            CharacterId = cstCharacterId;
            NowLevel = cstLevel;
            ObtainExperiencePoint = cstObtainExperiencePoint;
            CharacterName = cstCharacterName;
            Gender = cstGender;
            Deathblow1 = cstDeathblow1;
            Deathblow2 = cstDeathblow2;
            Deathblow3 = cstDeathblow3;
            HitPoint = cstHitPoint;
            NowHitPoint = cstHitPoint;
            MagicPoint = cstMagicPoint;
            Status = cstStatus;
            ImagPass = cstImagPass;
            EffectPass1 = csteffectPass1;
            EffectPass2 = csteffectPass2;
            EffectPass3 = csteffectPass3;
            EncounterPass = cstencounterPass;
        }
        #endregion

        #region PrintData
        /// <summary>
        /// キャラクター情報を引き出して文字列を返す
        /// </summary>
        /// <param name="index">配列のインデックス番号</param>
        /// <returns>文字列</returns>
        public string PrintData()
        {

            return "Level" + NowLevel + NowHitPoint + "/" + HitPoint + "\r\n" +
                   "名前：" + CharacterName + "\r\n" +
                   "性別：" + Gender + "\r\n" +
                   "技" + "・" + Deathblow1 + "・" + Deathblow2 + "・" + Deathblow3 + "\r\n" +
                   "HP：" + HitPoint + " / MP：" + MagicPoint + "\r\n" +
                   "ステータス：" + Status + "\r\n" +
                   NowHitPoint + "/" + HitPoint;
        }

        /// <summary>
        /// ダメージ計算後のキャラクターデータ表示
        /// </summary>
        /// <param name="Damage">ダメージ</param>
        /// <returns>キャラクターデータ文字列</returns>
        public string CombatData(int Damage)
        {
            NowHitPoint = NowHitPoint - Damage;
            return "Level" + NowLevel + "  " + NowHitPoint + "/" + HitPoint + "\r\n" +
                   "名前：" + CharacterName + "\r\n" +
                   "性別：" + Gender + "\r\n" +
                   "技" + "・" + Deathblow1 + "・" + Deathblow2 + "・" + Deathblow3 + "\r\n" +
                   "HP：" + HitPoint + " / MP：" + MagicPoint + "\r\n" +
                   "ステータス：" + Status + "\r\n" + "\r\n" +
                   "HP" + NowHitPoint + "/" + HitPoint;
        }
        #endregion

        #region Calculation
        /// <summary>
        /// 攻撃ダメージの計算
        /// </summary>
        /// <returns>攻撃ダメージ数</returns>
        public int Power()
        {
            int poweri = NowLevel * PowerLevel;
            return poweri;
        }

        /// <summary>
        /// 防御力の計算
        /// </summary>
        /// <returns>防御力</returns>
        public int Defense()
        {
            int defensei = NowLevel * DefenseLevel;
            return defensei;
        }
        #endregion

        #region DeathblowProcessing
        /// <summary>
        /// 対応する技の検索
        /// </summary>
        /// <param name="DeathblowNumber">欲しい技の番号</param>
        /// <returns>技の文字列</returns>
        public string Deathblowes(int DeathblowNumber)
        {
            string[] Deathblowes = { Deathblow1, Deathblow2, Deathblow3 };
            return Deathblowes[DeathblowNumber];
        }

        /// <summary>
        /// キャラクターの技の総数
        /// </summary>
        /// <returns>技の総数</returns>
        public int DeathblowesNumber()
        {
            string[] Deathblowes = { Deathblow1, Deathblow2, Deathblow3 };
            int DeathblowNumber = Deathblowes.Length;
            return DeathblowNumber;
        }

        /// <summary>
        /// 対応する技エフェクトの検索
        /// </summary>
        /// <param name="DeathblowNumber">技の番号</param>
        /// <returns>対応する技エフェクト</returns>
        public string DeathblowesEffect(int DeathblowNumber)
        {
            string[] DeathblowesPass = { EffectPass1, EffectPass2, EffectPass3 };
            return DeathblowesPass[DeathblowNumber];
        }
        #endregion


    }
}
