// XInstallerDlg.cpp : implementation file
//

#include "stdafx.h"
#include "XInstaller.h"
#include "XInstallerDlg.h"
#include "atlbase.h"
#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CXInstallerDlg dialog




CXInstallerDlg::CXInstallerDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CXInstallerDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CXInstallerDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CXInstallerDlg, CDialog)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()


// CXInstallerDlg message handlers

BOOL CXInstallerDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	if(!SwitchOnAdministrator())
	{
		int res = MessageBox("For setup of this program rights for an administrator are needed.\n Try setup with current rights?","Exit programm",MB_YESNO | MB_ICONWARNING);
		if(res == IDNO)
		{
			exit(0);
		}
	}
	
	Install();
	
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}
void CXInstallerDlg::InstallFramework()
{
	    STARTUPINFO si;
		PROCESS_INFORMATION pi;

		ZeroMemory( &si, sizeof(si) );
		si.cb = sizeof(si);
		ZeroMemory( &pi, sizeof(pi) );

		CString curDir;
		CString dotnet("dotnetfx.exe");
		GetCurrentDirectory(MAX_PATH,curDir.GetBuffer(MAX_PATH));

		CString CurPath;
		CurPath.Format("\"%s\\%s\"",curDir,dotnet);

		// Start the child process. 
		if( !CreateProcess( NULL,   // No module name (use command line). 
			CurPath.GetBuffer(), // Command line. 
		NULL,             // Process handle not inheritable. 
		NULL,             // Thread handle not inheritable. 
		FALSE,            // Set handle inheritance to FALSE. 
		0,                // No creation flags. 
		NULL,             // Use parent's environment block. 
		NULL,             // Use parent's starting directory. 
		&si,              // Pointer to STARTUPINFO structure.
		&pi )             // Pointer to PROCESS_INFORMATION structure.
		) 
		{
			MessageBox("Error of start of installation of Framework 2.0. For continuation it is necessary to set Framework not below 2.0.You can set him by hand. Then it is a report not to appear.");
			exit(0);
		}
		else 
		{
			WaitForSingleObject(pi.hProcess,INFINITE);
		}

		CloseHandle( pi.hProcess );
        CloseHandle( pi.hThread );

}
void CXInstallerDlg::RunSetupUI()
{
    STARTUPINFO si;
	PROCESS_INFORMATION pi;

	ZeroMemory( &si, sizeof(si) );
	si.cb = sizeof(si);
	ZeroMemory( &pi, sizeof(pi) );

	CString path;
	path.Format("\"SetupUI.exe\" -Installing");

	if( !CreateProcess( NULL,   // No module name (use command line). 
		path.GetBuffer(), // Command line. 
	NULL,             // Process handle not inheritable. 
	NULL,             // Thread handle not inheritable. 
	FALSE,            // Set handle inheritance to FALSE. 
	0,                // No creation flags. 
	NULL,             // Use parent's environment block. 
	NULL,             // Use parent's starting directory. 
	&si,              // Pointer to STARTUPINFO structure.
	&pi )             // Pointer to PROCESS_INFORMATION structure.
	) 
	{
		MessageBox("Starting Setup failed","Error",MB_OK | MB_ICONERROR);
		exit(0);
	}

	CloseHandle( pi.hProcess );
    CloseHandle( pi.hThread );
}
void CXInstallerDlg::Install()
{
	if(!GetVertionFramework())
	{
	    MessageBox("For setup this program, you most setup Framework 2.0","Messenger Setup",MB_OK | MB_ICONINFORMATION);
		InstallFramework();

		if(!GetVertionFramework())
		{
			MessageBox("For setup this program, first setup Framework 2.0","Messenger Setup",MB_OK | MB_ICONERROR);
			exit(0);
		}
	}
		
	RunSetupUI();

	exit(0);
	
}
BOOL CXInstallerDlg::GetVertionFramework()
{
	CRegKey Key(HKEY_LOCAL_MACHINE);
	LONG error = Key.Open(HKEY_LOCAL_MACHINE,"Software\\Microsoft\\.NETFramework\\Policy\\v2.0",KEY_READ);
	BOOL installed = FALSE;

	if(error == ERROR_SUCCESS)
	{
		Key.Close();
		installed  =  TRUE;
	}
	else if(error == ERROR_ACCESS_DENIED)
	{
		MessageBox("Error read regkey. The attempt of setup will be made without verifications","Messenger Setup", MB_OK | MB_ICONWARNING);
		installed  =  TRUE;
	}


	return installed;
}
void CXInstallerDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

HCURSOR CXInstallerDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}

BOOL CXInstallerDlg::SwitchOnAdministrator()
{
	 // включим привилегию SE_DEBUG_NAME и попробуем еще раз
		
		DWORD dwError;

        TOKEN_PRIVILEGES Priv, PrivOld;
        DWORD cbPriv = sizeof(PrivOld);
        HANDLE hToken;

        // получаем токен текущего потока 
        if (!OpenThreadToken(GetCurrentThread(), 
                             TOKEN_QUERY|TOKEN_ADJUST_PRIVILEGES,
                             FALSE, &hToken))
        {
            if (GetLastError() != ERROR_NO_TOKEN)
                return FALSE;

            // используем токен процесса, если потоку не назначено
    // никакого токена
            if (!OpenProcessToken(GetCurrentProcess(),
                                  TOKEN_QUERY|TOKEN_ADJUST_PRIVILEGES,
                                  &hToken))
                return FALSE;
        }

        _ASSERTE(ANYSIZE_ARRAY > 0);

        Priv.PrivilegeCount = 1; 
        Priv.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;
        LookupPrivilegeValue(NULL, SE_DEBUG_NAME, &Priv.Privileges[0].Luid);

        // попробуем включить привилегию
        if (!AdjustTokenPrivileges(hToken, FALSE, &Priv, sizeof(Priv),
                                   &PrivOld, &cbPriv))
        {
            dwError = GetLastError();
            CloseHandle(hToken);
            return SetLastError(dwError), FALSE;
        }

        if (GetLastError() == ERROR_NOT_ALL_ASSIGNED)
        {
            // привилегия SE_DEBUG_NAME отсутствует в токене
            // вызывающего
            CloseHandle(hToken);
            return SetLastError(ERROR_ACCESS_DENIED), FALSE;
        }

		return TRUE;
}