<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 게임
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.EnergyBar = New System.Windows.Forms.ProgressBar()
        Me.btnGameStart = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lbInfo0 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbGameTime = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbInfo1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbScore = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.메뉴ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.GameTimer = New System.Windows.Forms.Timer(Me.components)
        Me.UpdateTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'EnergyBar
        '
        Me.EnergyBar.Location = New System.Drawing.Point(192, 25)
        Me.EnergyBar.Name = "EnergyBar"
        Me.EnergyBar.Size = New System.Drawing.Size(41, 6)
        Me.EnergyBar.Step = -20
        Me.EnergyBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.EnergyBar.TabIndex = 7
        Me.EnergyBar.Value = 100
        '
        'btnGameStart
        '
        Me.btnGameStart.Font = New System.Drawing.Font("굴림체", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnGameStart.Location = New System.Drawing.Point(244, 140)
        Me.btnGameStart.Name = "btnGameStart"
        Me.btnGameStart.Size = New System.Drawing.Size(100, 50)
        Me.btnGameStart.TabIndex = 5
        Me.btnGameStart.Text = "Start"
        Me.btnGameStart.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbInfo0, Me.lbGameTime, Me.lbInfo1, Me.lbScore})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 320)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(584, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lbInfo0
        '
        Me.lbInfo0.BackColor = System.Drawing.Color.Transparent
        Me.lbInfo0.Name = "lbInfo0"
        Me.lbInfo0.Size = New System.Drawing.Size(58, 17)
        Me.lbInfo0.Text = "게임시간:"
        '
        'lbGameTime
        '
        Me.lbGameTime.BackColor = System.Drawing.Color.Transparent
        Me.lbGameTime.Name = "lbGameTime"
        Me.lbGameTime.Size = New System.Drawing.Size(21, 17)
        Me.lbGameTime.Text = "30"
        '
        'lbInfo1
        '
        Me.lbInfo1.BackColor = System.Drawing.Color.Transparent
        Me.lbInfo1.Name = "lbInfo1"
        Me.lbInfo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbInfo1.Size = New System.Drawing.Size(54, 17)
        Me.lbInfo1.Text = "     점수:"
        '
        'lbScore
        '
        Me.lbScore.BackColor = System.Drawing.Color.Transparent
        Me.lbScore.Name = "lbScore"
        Me.lbScore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbScore.Size = New System.Drawing.Size(14, 17)
        Me.lbScore.Text = "0"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.메뉴ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(584, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '메뉴ToolStripMenuItem
        '
        Me.메뉴ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuExit})
        Me.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem"
        Me.메뉴ToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.메뉴ToolStripMenuItem.Text = "메뉴"
        '
        'menuExit
        '
        Me.menuExit.Name = "menuExit"
        Me.menuExit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.menuExit.Size = New System.Drawing.Size(153, 22)
        Me.menuExit.Text = "종료(&E)"
        '
        'GameTimer
        '
        Me.GameTimer.Interval = 1000
        '
        'UpdateTimer
        '
        Me.UpdateTimer.Enabled = True
        Me.UpdateTimer.Interval = 33
        '
        '게임
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(584, 342)
        Me.Controls.Add(Me.EnergyBar)
        Me.Controls.Add(Me.btnGameStart)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Name = "게임"
        Me.Text = "Form1"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents EnergyBar As ProgressBar
    Friend WithEvents btnGameStart As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lbInfo0 As ToolStripStatusLabel
    Friend WithEvents lbGameTime As ToolStripStatusLabel
    Friend WithEvents lbInfo1 As ToolStripStatusLabel
    Friend WithEvents lbScore As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 메뉴ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents menuExit As ToolStripMenuItem
    Friend WithEvents GameTimer As Timer
    Friend WithEvents UpdateTimer As Timer
End Class
