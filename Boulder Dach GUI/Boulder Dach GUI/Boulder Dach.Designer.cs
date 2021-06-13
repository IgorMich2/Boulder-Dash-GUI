
namespace Boulder_Dach_GUI
{
    partial class BoulderForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoulderForm));
            this.SuspendLayout();
            // 
            // BoulderForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.KeyPreview = true;
            this.Name = "BoulderForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BoulderForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BoulderForm_FormClosed);
            this.Load += new System.EventHandler(this.BoulderForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BoulderForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

