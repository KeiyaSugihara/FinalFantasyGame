using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalFantasy
{
    public partial class FormCharacterData : Form
    {
        #region Field
        List<CharacterData> Characters = new List<CharacterData>();
        List<EnemyData> Enemyes = new List<EnemyData>();
        List<Label> LabelCharacters = new List<Label>();
        List<Label> LabelEnemyes = new List<Label>();
        Rectangle Rect;
        int RepetitionNumber = 0;
        int enemyesId = 0;
        int enemyDataCount;
        int CharacterDataCount;
        int enemyesLabelId = 0;
        int EnemyeNowDeathblowNum = 0;
        int CharaNowDeathblowNum = 0;
        private Bitmap _image = null;
        int FormClosedNum;
        int CharacterNum;
        int ContinueCount = 10;
        #endregion

        #region Constructor
        /// <summary>
        /// コンストラクタ―
        /// </summary>
        public FormCharacterData()
        {
            InitializeComponent();
            AllEnemyData();
            AllCharacterData();
            Rect = new Rectangle();
        }
        #endregion

        #region InsideProcessing
        /// <summary>
        /// ファイルデータからキャラクターインスタンスの作成
        /// </summary>
        private void AllCharacterData()
        {
            StreamReader sr = new StreamReader(@"C:.\..\..\Characters.csv", Encoding.GetEncoding("UTF-8"));
            string stResult = string.Empty;
            while (sr.Peek() >= 0)
            {
                string stBuffer = sr.ReadLine();
                stResult += stBuffer + Environment.NewLine;
            }
            sr.Close();

            string[] del = { "\r\n" };
            // 段らく区切りで分割して配列に格納する
            string[] CharacterData = stResult.Split(del, StringSplitOptions.None);
            CharacterDataCount = CharacterData.Length;
            string CharacterConfiguration;
            string[] eachCharacter;

            for (int i = 0; i < CharacterDataCount - 1; i++)
            {
                CharacterConfiguration = CharacterData[i];
                eachCharacter = CharacterConfiguration.Split(',');

                Characters.Add(new CharacterData(int.Parse(eachCharacter[0]), int.Parse(eachCharacter[1]),
                      eachCharacter[2], eachCharacter[3], eachCharacter[4], eachCharacter[5],
                      eachCharacter[6], int.Parse(eachCharacter[7]), int.Parse(eachCharacter[8]), eachCharacter[9],
                      eachCharacter[10], eachCharacter[11], eachCharacter[12]));
            }
        }

        /// <summary>
        /// ファイルデータから敵インスタンスの作成
        /// </summary>
        private void AllEnemyData()
        {
            StreamReader sr = new StreamReader(@"C:.\..\..\Enemys.csv", Encoding.GetEncoding("UTF-8"));
            string stResult = string.Empty;
            while (sr.Peek() >= 0)
            {
                string stBuffer = sr.ReadLine();
                stResult += stBuffer + Environment.NewLine;
            }
            sr.Close();
            string[] del = { "\r\n" };
            // 段らく区切りで分割して配列に格納する
            string[] enemyData = stResult.Split(del, StringSplitOptions.None);
            enemyDataCount = enemyData.Length;
            string enemyConfiguration;
            string[] eachEnemy;

            for (int i = 0; i < enemyDataCount - 1; i++)
            {
                enemyConfiguration = enemyData[i];
                eachEnemy = enemyConfiguration.Split(',');

                Enemyes.Add(new EnemyData(int.Parse(eachEnemy[0]), int.Parse(eachEnemy[1]),
                      int.Parse(eachEnemy[2]), eachEnemy[3], eachEnemy[4], eachEnemy[5],
                      eachEnemy[6], eachEnemy[7], int.Parse(eachEnemy[8]), int.Parse(eachEnemy[9]),
                      eachEnemy[10], eachEnemy[11], eachEnemy[12], eachEnemy[13], eachEnemy[14], eachEnemy[15]));
            }
        }

        /// <summary>
        /// キャラクターのインデックスを取得
        /// </summary>
        /// <param name="name">キャラクター名</param>
        /// <returns></returns>
        private int IndexOfCharacter(string name)
        {
            int index = 0;

            // キャラクター検索
            foreach (CharacterData chara in Characters)
            {
                if (chara.CharacterName == name) break;
                index += 1;
            }
            return index;
        }

        /// <summary>
        /// エネミーのインデックスを取得
        /// </summary>
        /// <param name="name">エネミー名</param>
        /// <returns></returns>
        private int IndexOfEnemy(string name)
        {
            int index = 0;
            // キャラクター検索
            foreach (EnemyData enemy in Enemyes)
            {
                if (enemy.CharacterName == name) break;
                index += 1;
            }
            return index;
        }

        /// <summary>
        /// 指定時間処理を止める
        /// </summary>
        /// <param name="msec">インターバル</param>
        private void Sleep(long msec)
        {
            for (int i = 0; i < msec / 100; i++)
            {
                if (FormClosedNum == 1) break;
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
        }
        #endregion

        #region   Events

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCharacterData_Load(object sender, EventArgs e)
        {
            InitializeForm(false);
        }

        /// <summary>
        /// 冒険ボタンのイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void buttonAdventure_Click(object sender, EventArgs e)
        {
            AdventureEvents();
        }

        /// <summary>
        /// 攻撃ボタンのイベント
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void buttonFight_Click(object sender, EventArgs e)
        {
            FightEvents();
        }

        /// <summary>
        /// マウスのクリップポイントの比較
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxEnemy_MouseClick(object sender, MouseEventArgs e)
        {
            Point clickPoint = new Point(e.X, e.Y);
            if (Rect.Contains(clickPoint) == true)
            {
                DispAdventure("命中", 500);
                FightEvents();
            }
            else
            {
                RepetitionNumber++;
                DispAdventure("攻撃が外れました", 500);
                EnemyAttacks(0, 0);
                RepetitionNumber--;
            }
        }

        /// <summary>
        /// キーボード操作の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCharacterData_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && RepetitionNumber == 2)
            {
                FightEvents();
            }
            else if (e.KeyCode == Keys.Back)
            {
                DispAdventure("お疲れ様です", 1000);
                Application.Exit();
            }
            else if (e.KeyCode == Keys.Enter && RepetitionNumber == 0)
            {
                AdventureEvents();
            }
            else if (e.KeyCode == Keys.Enter && RepetitionNumber == 4 && ContinueCount != 0)
            {
                RepetitionNumber--;
                RepetitionNumber--;
                ContinueCount--;
                Continue();
                DispAdventure("攻撃 :Enter  or  敵をクリック", 0);
                pictureBoxEnemy.Enabled = true;
            }
            else if (e.KeyCode == Keys.Enter && RepetitionNumber == 4 && ContinueCount == 0)
            {
                Restart();
                RepetitionNumber = 0;
            }
        }

        /// <summary>
        /// フォーム×で終了時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCharacterData_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedNum = 1;
            Application.Exit();
            MessageBox.Show("強制終了しました。");
        }

        /// <summary>
        /// ImageAnimatorにファイルを入れる
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void PictureBoxEnemy_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(_image);
        }

        /// <summary>
        /// Paintイベントハンドラを呼び出す
        /// </summary>
        /// <param name="o">オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void Image_FrameChanged(object o, EventArgs e)
        {
            pictureBoxEnemy.Invalidate();
        }

        /// <summary>
        /// キャラクターデータの表示
        /// </summary>
        /// <param name="sender">オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void buttonCharacter_Click(object sender, EventArgs e)
        {
            int count = Characters.Count;
            try
            {
                for (int i = 0; i < count; i++)
                {
                    labelCharacter.Text = Characters[i].PrintData();
                    Sleep(2000);
                }
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region DisplayOutput

        /// <summary>
        /// 冒険テキスト
        /// </summary>
        /// <param name="EnemyesId">出現敵のID</param>
        private void AdventureText(int EnemyesId)
        {
            RepetitionNumber++;
            DispAdventure("冒険にでました", 1000);
            DispAdventure("...", 1000);
            DispAdventure("......", 1000);
            DispAdventure(".........", 1000);
            ImageCreation(Enemyes[enemyesId].ImagPass);
            DispAdventure(Enemyes[enemyesId].CharacterName + "が現れた", 1000);
            DispEnemy(enemyesLabelId, Enemyes[enemyesId].CombatData(0), 1000);
            DispAdventure("戦闘中", 1000);
            DispAdventure("攻撃 :Enter  or  敵をクリック", 0);
            RepetitionNumber++;
        }

        /// <summary>
        /// 冒険メッセージの表示
        /// </summary>
        /// <param name="message">メッセージ</param>
        /// <param name="sleepMsec">待機時間(msec)</param>
        private void DispAdventure(string message, int sleepMsec)
        {
            labelAdventure.Text = message;
            Sleep(sleepMsec);
        }

        /// <summary>
        /// 敵メッセージの表示
        /// </summary>
        /// <param name="enemyId">敵ID</param>
        /// <param name="message">メッセージ</param>
        /// <param name="sleepMsec">待機時間(msec)</param>
        private void DispEnemy(int enemyesLabelId, string message, int sleepMsec)
        {
            LabelEnemyes[enemyesLabelId].Text = message;
            Sleep(sleepMsec);
        }

        /// <summary>
        /// キャラクターメッセージの表示
        /// </summary>
        /// <param name="enemyId">キャラクターID</param>
        /// <param name="message">メッセージ</param>
        /// <param name="sleepMsec">待機時間(msec)</param>
        private void DispChara(int charaId, string message, int sleepMsec)
        {
            LabelCharacters[charaId].Text = message;
            Sleep(sleepMsec);
        }
        #endregion

        #region GameContents
        /// <summary>
        /// 冒険ボタンのイベントの中身
        /// </summary>
        private void AdventureEvents()
        {
            buttonAdventure.Enabled = false;
            int firstDamage = 0;
            if (enemyesId == enemyDataCount) enemyesId = 0;
            for (int c = 0; c < Characters.Count; c++)
            {
                DispChara(c, Characters[c].CombatData(firstDamage), 0);
            }
            AdventureText(enemyesId);
            buttonFight.Enabled = true;
            pictureBoxEnemy.Enabled = true;
        }

        /// <summary>
        /// 攻撃ボタンのイベント、戦闘データ表示機能
        /// </summary>
        private void FightEvents()
        {
            RepetitionNumber++;
            pictureBoxEnemy.Enabled = false;
            buttonFight.Enabled = false;
            int index = Characters.Count;
            int earisId = IndexOfCharacter("エアリス");
            while (true)
            {
                if (FormClosedNum == 1) break;
                EnemyData enemy = Enemyes[enemyesId];
                for (int i = 0; i < index; i++)
                {
                    if (FormClosedNum == 1) break;
                    CharacterData chara = Characters[i];
                    // 全キャラで順次攻撃
                    DispAdventure(chara.CharacterName + "のターン", 1000);
                    int number = chara.DeathblowesNumber();
                    if (i == earisId && CharaNowDeathblowNum == 0)
                    {
                        // 回復のターン(エアリスの癒しの風)
                        DispAdventure(chara.Deathblowes(CharaNowDeathblowNum), 1000);
                        EnemyEffect(chara.DeathblowesEffect(CharaNowDeathblowNum));
                        DispAdventure("全キャラ" + chara.Power() + "の回復", 1000);
                        for (int c = 0; c < Characters.Count; c++)
                        {
                            if (FormClosedNum == 1) break;
                            CharacterData Chara = Characters[c];
                            DispChara(c, Chara.HitPointRecovery(chara.Power()), 0);
                        }

                    }
                    else
                    {
                        // 通常攻撃(エアリスの癒しの風以外)
                        if (FormClosedNum == 1) break;
                        DispAdventure(chara.Deathblowes(CharaNowDeathblowNum), 1000);
                        Effect(chara.DeathblowesEffect(CharaNowDeathblowNum));
                        DispAdventure(enemy.CharacterName +
                            (chara.Power() - enemy.Defense()) + "のダメージ", 1000);
                        DispEnemy(enemyesLabelId, enemy.CombatData(chara.Power() - enemy.Defense()), 0);
                        if (enemy.NowHitPoint < 0) break;
                    }
                }
                // 敵を倒した場合
                if (enemy.NowHitPoint < 0)
                {
                    if (FormClosedNum == 1) break;
                    DefeatedEnemy(enemyesId);
                    buttonAdventure.Enabled = true;
                    DispAdventure("冒険に出ますか　はい :Enter  いいえ Back", 0);
                    enemyesId++;
                    break;
                }
                // 敵の攻撃
                if (FormClosedNum == 1) break;
                int EnemyeDeathblowNumber = enemy.DeathblowesNumber();
                EnemyAttacks(enemyesId, EnemyeDeathblowNumber);
                if (Characters[0].NowHitPoint == 0 || Characters[1].NowHitPoint == 0 ||
                Characters[2].NowHitPoint == 0 || Characters[3].NowHitPoint == 0)
                {
                    break;
                }
                else
                {
                    if (FormClosedNum == 1) break;
                    DispAdventure("攻撃 :Enter  or  敵をクリック", 0);
                    pictureBoxEnemy.Enabled = true;
                    CharaNowDeathblowNum++;
                    if (CharaNowDeathblowNum == 3) CharaNowDeathblowNum = 0;
                    RepetitionNumber--;
                    break;
                }
            }
        }

        /// <summary>
        /// 敵の攻撃
        /// </summary>
        /// <param name="EnemyesId">敵のID</param>
        /// <param name="EnemyeDeathblowNumber">技の初期値</param>
        private void EnemyAttacks(int EnemyesId, int EnemyeDeathblowNumber)
        {
            pictureBoxEnemy.Enabled = false;
            EnemyData enemy = Enemyes[EnemyesId];
            DispAdventure(enemy.CharacterName + "の攻撃", 1000);

            DispAdventure(enemy.Deathblowes(EnemyeNowDeathblowNum), 1000);
            EnemyEffect(enemy.DeathblowesEffect(EnemyeNowDeathblowNum));
            EnemyeNowDeathblowNum++;
            if (EnemyeNowDeathblowNum == EnemyeDeathblowNumber) EnemyeNowDeathblowNum = 0;
            // 仲間が死んだとき
            for (int c = 0; c < Characters.Count; c++)
            {
                CharacterData Chara = Characters[c];
                DispAdventure(Chara.CharacterName +
                    Chara.CharactersDamage(enemy.Power()) + "のダメージ", 1000);
                DispChara(c, Chara.CombatData(Chara.CharactersDamage(enemy.Power())), 0);
                if (Chara.NowHitPoint < 0)
                {
                    Chara.NowHitPoint = 0;
                    DispChara(c, Chara.CombatData(0), 0);
                    DispAdventure(Chara.CharacterName + "が倒れました", 1000);
                    DispAdventure("Game over", 1000);
                    RepetitionNumber++;
                    CharacterNum = c;
                    break;
                }
            }
            if (Characters[0].NowHitPoint != 0 && Characters[1].NowHitPoint != 0 &&
                Characters[2].NowHitPoint != 0 && Characters[3].NowHitPoint != 0)
            {
                DispAdventure("敵を狙え", 1000);
                DispAdventure("戦闘中", 0);
                pictureBoxEnemy.Enabled = true;
            }
            else
            {
                InitializeForm(true);
            }
        }

        /// <summary>
        /// 敵を倒した時のテキストと経験値処理
        /// </summary>
        /// <param name="EnemyesId">敵のID</param>
        private void DefeatedEnemy(int EnemyesId)
        {
            EnemyData enemy = Enemyes[EnemyesId];
            enemy.NowHitPoint = 0;
            DispEnemy(enemyesLabelId, enemy.CombatData(0), 1000);
            DispAdventure(enemy.CharacterName + "を倒しました", 1000);
            DispAdventure(enemy.ObtainExperiencePoint + "の経験値獲得", 1000);
            for (int c = 0; c < Characters.Count; c++)
            {
                CharacterData Chara = Characters[c];
                DispAdventure(Chara.CharacterName + Chara.Level(enemy.ObtainExperiencePoint), 0);
                DispChara(c, Chara.CombatData(0), 1000);
            }
            DispEnemy(enemyesLabelId, "", 0);
            pictureBoxEnemy.BackgroundImage = null;
            enemy.NowHitPoint = enemy.HitPoint;
            DispAdventure("", 500);
            RepetitionNumber = 0;
        }

        #endregion

        #region RestartForm
        /// <summary>
        /// フォーム初期化
        /// </summary>
        /// <param name="restart"></param>
        private void InitializeForm(bool restart)
        {
            // 画面の初期化
            if (!restart)
            {
                LabelCharacters.AddRange(new List<Label>()
                                        {labelCraudo, labelTifa, labelEaris, labelBarrett });
                LabelEnemyes.AddRange(new List<Label>()
                                        {labelEnemy});
                // 冒険開始
                pictureBoxEnemy.Enabled = false;
                DispAdventure("冒険に出ますか　はい :Enter  いいえ Back", 0);
            }

            // キャラクターの初期化
            if (restart && ContinueCount == 0)
            {
                // キャラクターのレベルを元に戻す
                DispAdventure("はじめから　はい :Enter  いいえ Back", 0);
            }
            else if (restart && ContinueCount > 0)
            {
                // レベルを継続する
                DispAdventure("continue 残り" + ContinueCount, 1000);
                DispAdventure("continue？　はい :Enter  いいえ Back", 0);
            }
        }

        /// <summary>
        /// リスタート時のパラメータリセット
        /// </summary>
        private void Restart()
        {
            pictureBoxEnemy.BackgroundImage = null;
            for (int i = 0; i < 4; i++)
            {
                EnemyData enemy = Enemyes[i];
                CharacterData chara = Characters[i];
                chara.NowLevel = 30;
                chara.NowHitPoint = chara.HitPoint;
                enemy.NowHitPoint = enemy.HitPoint;
                int firstDamage = 0;
                for (int c = 0; c < Characters.Count; c++)
                {
                    DispChara(c, Characters[c].CombatData(firstDamage), 0);
                }
            }
        }

        /// <summary>
        /// コンティニューHitPointリセット
        /// </summary>
        private void Continue()
        {
            for (int i = 0; i < 4; i++)
            {
                CharacterData chara = Characters[i];
                chara.NowHitPoint = chara.HitPoint;
                int firstDamage = 0;
                for (int c = 0; c < Characters.Count; c++)
                {
                    DispChara(c, Characters[c].CombatData(firstDamage), 0);
                }
            }
        }
        #endregion

        #region GameImage
        /// <summary>
        /// 敵の上に技のエフェクトの描写
        /// </summary>
        /// <param name="effectPass">技のパス</param>
        private void Effect(string effectPass)
        {
            _image = new Bitmap(System.IO.Path.Combine(Application.StartupPath, @"C:.\..\..\images\" + effectPass));
            // pictureBox1の背景画像としてセット 
            pictureBoxEnemy.Image = _image;

            // 描画(Paint)イベントハンドラを追加
            pictureBoxEnemy.Paint += PictureBoxEnemy_Paint;
            // アニメーション開始
            ImageAnimator.Animate(_image, new EventHandler(Image_FrameChanged));
            Sleep(1400);
            ImageAnimator.StopAnimate(_image, new EventHandler(Image_FrameChanged));
            pictureBoxEnemy.Image = null;
        }

        /// <summary>
        /// 技のエフェクトの描写
        /// </summary>
        /// <param name="enemyEffectPass">エフェクトのパス</param>
        private void EnemyEffect(string enemyEffectPass)
        {
            Image img = Image.FromFile(@"C:.\..\..\images\" + enemyEffectPass);
            pictureBoxEnemy2.Image = img;
            Sleep(1500);
            pictureBoxEnemy2.Image = null;
        }

        /// <summary>
        /// 画像の読み込みと編集
        /// </summary>
        /// <param name="imagPass">パス</param>
        private void ImageCreation(string imagPass)
        {
            //ビットマップ版
            Bitmap canvas = new Bitmap(pictureBoxEnemy.Width, pictureBoxEnemy.Height);
            Graphics g = Graphics.FromImage(canvas);
            Image img = Image.FromFile(@"C:.\..\..\images\" + imagPass);

            switch (enemyesId)
            {
                case 0:
                    Rect = new Rectangle(120, 0, (int)(img.Width * 0.6), (int)(img.Height * 0.6));
                    break;
                case 1:
                    Rect = new Rectangle(80, 0, (int)(img.Width * 0.6), (int)(img.Height * 0.6));
                    break;
                case 2:
                    Rect = new Rectangle(20, 0, (int)(img.Width * 0.6), (int)(img.Height * 0.55));
                    break;
                case 3:
                    Rect = new Rectangle(50, 10, (int)(img.Width * 0.6), (int)(img.Height * 0.6));
                    break;
                default:
                    break;
            }
            g.DrawImage(img, Rect);
            g.Dispose();
            pictureBoxEnemy.BackgroundImage = canvas;
        }

        #endregion

    }
}
