# UI & Mobile Automation Framework

This project provides a robust **C# automation framework** for **UI and Mobile testing**, supporting both **TDD (Test-Driven Development)** and **BDD (Behavior-Driven Development)** methodologies.  

It is designed for scalability, configurability, and ease of integration into CI/CD pipelines, generating comprehensive reports for passed and failed test cases.

---

## 🚀 Features


- ✅ **TDD and BDD** style test case support  
- ✅ **Customizable configuration** via `AppConfig.json`  
- ✅ **Automation test reports** with detailed results  
- ✅ **Automatic screenshots** for failed test cases  
- ✅ Easy integration with CI/CD tools 
- ✅ Reports and logs easily shareable with stakeholders  

---

## 🖥️ System Set Up

###  Visual Studio Set Up
- Install Visual Studio from [Visual Studio Downloads](https://visualstudio.microsoft.com/downloads/)
- Follow the installation guide as per project requirements.

###  Appium Server GUI
- Download Appium Server GUI from [Appium Releases](https://github.com/appium/appium-desktop/releases)
- Install and launch Appium Server GUI.

###  Appium Inspector
- Download Appium Inspector from [Appium Inspector Releases](https://github.com/appium/appium-inspector/releases)
- Use it for inspecting mobile apps' UI elements.

###  Node.js
- Install Node.js from [Node.js Downloads](https://nodejs.org/)
- Ensure Node.js is properly added to PATH.

###  Android Studio SDK
- Download and install Android Studio from [Android Studio](https://developer.android.com/studio)
- Set up the required SDK packages.

###  Vysor
- Download Vysor from [Vysor](https://www.vysor.io/)
- Install and use Vysor for mirroring and controlling Android devices.

###  Developer Settings

Enable Developer options from About device and perform the following steps in developer options:

1. Enable “Disable permission monitoring”
2. Enable “USB Debugging”
3. Enable “Wireless debugging” (if required)
4. Enable “Enable view attribute inspection”
5. Disable “Verify apps over USB”
6. Disable “Verify bytecode of debuggable apps”

---

# ⚙️ Framework Set Up

**How to import framework to Visual Studio**

✪ Unzip the downloaded project.  
✪ In Visual Studio, click on **Open a project or solution**.  
✪ Select the `*.sln` file from the project.  
✪ Click on **Open**.  
✪ The project will open in Solution Explorer as below.

---

## ⚙️ Configuration

You can customize key settings in **`AppConfig.json`**, including:

- **User credentials**  
- **Environment details** (base URLs, devices)  
- **Test framework settings** (timeouts)  
- **Screenshot settings**  

---

## 📊 Reports & Logs

- After execution, reports are generated inside the **`Reports`** directory.  
- Screenshots for failed test cases are stored in **`FailedTestcases`**.  

Reports include:
- ✅ Test Summary (Total, Passed, Failed, Skipped)  
- ✅ Detailed step logs  
- ✅ Screenshots for failed steps




 

