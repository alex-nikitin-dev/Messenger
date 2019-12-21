// XInstallerDlg.h : header file
//

#pragma once


// CXInstallerDlg dialog
class CXInstallerDlg : public CDialog
{
// Construction
public:
	CXInstallerDlg(CWnd* pParent = NULL);	// standard constructor
	BOOL SwitchOnAdministrator();
	void Install();
	BOOL GetVertionFramework();
	void InstallFramework();
	BOOL MoveMainPack();
	void RunSetupUI();

// Dialog Data
	enum { IDD = IDD_XINSTALLER_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
};
