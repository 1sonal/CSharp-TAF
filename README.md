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
