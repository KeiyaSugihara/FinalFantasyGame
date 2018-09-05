using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalFantasy
{
   

    class CharacterData
    {
        #region Field
        private const string LineFeed = "\r\n";
        private const int PowerLevel = 10;
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
        public int ExperiencePoint { get; set; }
        public int NowExperiencePoint { get; set; }
        public string EffectPass1 { get; set; }
        public string EffectPass2 { get; set; }
        public string EffectPass3 { get; set; }
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
        public CharacterData(int cstCharacterId, int cstLevel, string cstCharacterName, string cstGender,
                             string cstDeathblow1, string cstDeathblow2,
                             string cstDeathblow3, int cstHitPoint,
                             int cstMagicPoint, string cstStatus,
                             string csteffectPass1, string csteffectPass2, string csteffectPass3)
        {
            CharacterId = cstCharacterId;
            NowLevel = cstLevel;
            CharacterName = cstCharacterName;
            Gender = cstGender;
            Deathblow1 = cstDeathblow1;
            Deathblow2 = cstDeathblow2;
            Deathblow3 = cstDeathblow3;
            HitPoint = cstHitPoint;
            NowHitPoint = cstHitPoint;
            MagicPoint = cstMagicPoint;
            Status = cstStatus;
            EffectPass1 = csteffectPass1;
            EffectPass2 = csteffectPass2;
            EffectPass3 = csteffectPass3;
            ExperiencePoint = 0;
            NowExperiencePoint = 0;
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
            string data = "";
            data += "Level" + NowLevel + LineFeed;
            data += "名前：" + CharacterName + LineFeed;
            data += "性別：" + Gender + LineFeed;
            data += "得意技：" + "・" + Deathblow1 + "・" + Deathblow2 + "・" + Deathblow3 + LineFeed;
            data += "HP：" + HitPoint + " / MP：" + MagicPoint + LineFeed;
            data += "ステータス：" + Status + LineFeed;
            return data;
        }

        /// <summary>
        /// キャラクター情報を引き出して文字列を返す
        /// 戦闘画面用
        /// </summary>
        /// <param name="index">配列のインデックス番号</param>
        /// <returns>文字列</returns>
        public string FighttData()
        {
            string data = "";
            data += "Level" + NowLevel + LineFeed;
            data += "名前：" + CharacterName + LineFeed;
            data += "性別：" + Gender + LineFeed;
            data += "得意技：" + "・" + Deathblow1 + "・" + Deathblow2 + "・" + Deathblow3 + LineFeed;
            data += "HP：" + HitPoint + " / MP：" + MagicPoint + LineFeed;
            data += "ステータス：" + Status + LineFeed;
            data += NowHitPoint + "/" + HitPoint;
            return data;
        }

        /// <summary>
        /// ダメージ計算後のキャラクターデータ表示
        /// </summary>
        /// <param name="Damage">ダメージ</param>
        /// <returns>キャラクターデータ文字列</returns>
        public string CombatData(int Damage)
        {
            NowHitPoint = NowHitPoint - Damage;
            string data = "";
            data += "Level" + NowLevel + LineFeed;
            data += "名前：" + CharacterName + LineFeed;
            data += "性別：" + Gender + LineFeed;
            data += "得意技：" + "・" + Deathblow1 + "・" + Deathblow2 + "・" + Deathblow3 + LineFeed;
            data += "HP：" + HitPoint + " / MP：" + MagicPoint + LineFeed;
            data += "ステータス：" + Status + LineFeed;
            data += NowHitPoint + "/" + HitPoint;
            return data;
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

        /// <summary>
        /// 敵の攻撃力からキャラクターの防御力を引く
        /// </summary>
        /// <param name="EnemyePower">敵の攻撃力</param>
        /// <returns>受けるダメージ</returns>
        public int CharactersDamage(int EnemyePower)
        {
            return (EnemyePower - Defense());
        }

        /// <summary>
        /// レベルアップの計算
        /// </summary>
        /// <param name="nowLevel">現在のレベル</param>
        /// <returns>計算後のレベル</returns>
        public string Level(int AcquisitionExperiencePoint)
        {
            RemainingExperiencePoint();
            if (ExperiencePoint <= AcquisitionExperiencePoint)
            {
                NowLevel++;
                return "レベルがあがりました" + NowLevel + "Level";
            }
            NowExperiencePoint += AcquisitionExperiencePoint;
            return "残り" + (ExperiencePoint - AcquisitionExperiencePoint) + "でレベルアップ";
        }

        /// <summary>
        /// 経験値テーブルの計算
        /// </summary>
        /// <param name="nowLevel">現在のレベル</param>
        /// <returns>次のレベルまでの経験値</returns>
        public void RemainingExperiencePoint()
        {
            ExperiencePoint = NowLevel * 500 - NowExperiencePoint;
        }

        /// <summary>
        /// HPの上限を超えた時のリセット
        /// </summary>
        /// <returns>リセット後かそのままのキャラクターデータ</returns>
        public string HitPointReset()
        {
            if (NowHitPoint > HitPoint)
            {
                NowHitPoint = HitPoint;
                return CombatData(0);
            }
            return CombatData(0);
        }

        /// <summary>
        /// 回復の計算
        /// </summary>
        /// <param name="PointRecovery">回復値</param>
        /// <returns>回復後のキャラクターデータ</returns>
        public string HitPointRecovery(int PointRecovery)
        {
            NowHitPoint += PointRecovery;
            return HitPointReset();
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

