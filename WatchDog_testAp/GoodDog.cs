using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using WatchDog;
using System.Data;

namespace WatchDog_testAp
    {
    class GoodDog
        {

        static void Main(string[] args)
            {
            FileInfo tstLFile;
            int cntTest = 1;
            //Test Log Setup
            string tstLgFName=@"C:\WatchDog\TestLog"+DateTime.Now.AddMinutes(55).ToString("yyyy_MM_dd-HH_mm_ss")+".txt";
            tstLFile = new FileInfo (@tstLgFName);
            StreamWriter tstLog = tstLFile.CreateText();
            tstLog.AutoFlush = true;
            tstLog.WriteLine("WatchDog ABC Class Library Test \n");
            //Test Data
            //General
            string tstTESTERID = "Tester";
            //Application Data
            string tstAPPNAME = "TEST_APPLICATION_TEST";
            string tstAPPDEL = "TEST_APPLICATION_DELETE_TEST";
            //Batch Data
            string tstBATCHNM = "TEST_BATCH_TEST";
            string tstBATCHNMDEL = "TEST BATCH DELETE TEST";
            string tstBATCHTYPE = "DAILY";
            //Batch Control Data
            string tstBATCHCNTRLNM = "Test Batch Control";
//            string tstBATCHCNTRLDEL = "Test Batch Control Delete Test";
            DateTime tstBATCHCNTRLDT = DateTime.Now;
            char tstBATCHCNTRLACTVIND = 'Y';
            DateTime tstBATCHSTRTDTTM = DateTime.Now;
            DateTime tstBATCHENDDTTM = DateTime.Now;
            DateTime tstBOUNDARYSTARTDT = DateTime.Now;
            DateTime tstBOUNDARYENDDT = DateTime.Now;
            tstBOUNDARYENDDT = tstBOUNDARYENDDT.AddDays(30);
            //Process Data
            string tstPROCESSIDNM = "TEST Process Id Name";
            string tstPROCESSTYPCD = "TEST Application";
            string tstPROCESSLOCATION="C:\\TestDrive";
            string tstPROCESSNM = "Test Process";
            string tstDELPROCESSNM = "Test Delete Process";
            //Audit Balance Defintion Data
            string tstSOURCEEXPRESSIONTXT = "SOURCE EXPRESSION";
            string tstSOURCE_EXPRESSION_TXT_DEL = "TEST EXPRESSION FOR DELETION";
            string tstOPERAND = "=";
            string tstTARGET_EXPRESSION_TXT = "TEST EXPRESSION";
            string tstABCFAILCRITICALFLAG = "N";
            string tstABC_TYP_IND = "C";
            //Process Control Data
            string tstPROCESSCNTRLSTS = "WAITING";
            DateTime tstPROCESSSTRDTTM = DateTime.Now;
            DateTime tstPROCESSENDDTTM = DateTime.Now;
            int tstPROCESSRESTRCNTR = 0;
            DateTime tstPROCESSINITSTRDTTM = DateTime.Now;
            //Process Property Data
            string tstPROPERTYNM = "Test Property";
            string tstPROPERTYNMDEL = "Delete Test Property";
            string tstPROPERTYVALUE = "Test Value";
            string tstPROPERTYVALUETYP = "C";
            //Process Control Stats Data
            string tstPROCESSCNTRLSTATNM = "Test Status";
            string tstPROCESSCNTRLSTATDESC = "Testing Control Status";
            string tstPROCESSCNTRLSTATTYP = "Text";
            string tstPROCESSCNTRLSTATVALU = "Test Data";
            //Process ABC
            string tstEXPECTED_VALUE = "VALUE";
            string tstACTUAL_VALUE = "VALUE";
            string tstABC_PASS_IND = "P";
            string tstPROCESS_BALANCE_IND = "Y";
            string tstPROCESS_CONTROL_IND = "Y";
            string tstPROCESS_AUDIT_IND = "P";
            string tstCRITICAL_FAIL_IND = "P";
            //Identifiers
            string tstAPPID = "";
            string tstBATCHID = "";
            string tstBATCHCNTRLID = "";
            string tstPROCESSID = "";
            string tstABCRULEID = "";
            string tstPROCESSCNTRLID = "";
            // End Test Data
            //Critcal Test create a new ABC object
            ABC Rover = new ABC();
            //Test 1 Define Application
            tstLog.WriteLine("Application Table Testing Beginning");
            int resTest1 = 0;
            resTest1 = Rover.DefineApplication(tstAPPNAME.ToString(), tstTESTERID.ToString());
            tstLog.WriteLine("Test "+cntTest.ToString()+" Results: " + resTest1.ToString());
            cntTest++;
            //Test 2: GetApplicationID
            var rezValue2a = Rover.GetApplicationID(tstAPPNAME.ToString());
            tstAPPID = rezValue2a.Item1;
            int ProcStat = rezValue2a.Item2;
            tstLog.WriteLine("Test " + cntTest.ToString() + " Results: " + tstAPPID.ToString() + " Status: " + ProcStat.ToString());
            cntTest++;
            //Test 3: GetApplication
            var prcTwo = Rover.GetApplication(tstAPPID.ToString(), tstAPPNAME.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + " Results:  Get Application Record ->");
            tstLog.WriteLine("APP_ID -> " + prcTwo.Item1.ToString() + " APP_NAME -> " + prcTwo.Item2.ToString() + " ENABLE_ID -> " + prcTwo.Item3.ToString() + " UPDATE_DTTM-> " + prcTwo.Item4.ToString() + " UPDATE_UID-> " + prcTwo.Item5.ToString() + " ProcessStatus-> " + prcTwo.Item6.ToString());
            cntTest++;
            //Test 4: Enable Application
            int resTest4 = 0;
            resTest4 = Rover.EnableApplication(tstAPPID, tstAPPNAME, tstTESTERID);
            //MessageBox.Show("Test 4 Results: " + resTest4.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + " Enable Application -> Results -> " + resTest4.ToString());
            cntTest++;
            //Test 5: Disable Application
            int resTest5 = 0;
            resTest5 = Rover.DisableApplication(tstAPPID, tstAPPNAME, tstTESTERID);
            //MessageBox.Show("Test 5 Results: " + resTest5.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + " Disable Application -> Results -> " + resTest5.ToString());
            cntTest++;
            //Test 6: Update Application
            int resTest6 = 0;
            resTest6 = Rover.UpdateApplication(tstAPPID, tstAPPNAME, "Y", tstTESTERID);
            //MessageBox.Show("Test 6 Results: " + resTest6.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + " Update Application -> Results -> " + resTest6.ToString());
            cntTest++;
            //Test 7: Delete Application
            int resTest7a = 0;
            resTest7a = Rover.DefineApplication(tstAPPDEL.ToString(), tstTESTERID.ToString());
            var rezValue7a = Rover.GetApplicationID(tstAPPDEL.ToString());
            string tstAPPIDDEL = rezValue7a.Item1;
            var prcSeven = Rover.GetApplication(tstAPPIDDEL.ToString(), tstAPPDEL.ToString());
            int resTest7 = 0;
            resTest7 = Rover.DeleteApplication(tstAPPIDDEL.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + " Delete Application Results: Step 1 Create Record -> " + resTest7a.ToString());
            tstLog.WriteLine("APP_ID -> " + prcSeven.Item1.ToString() + " APP_NAME -> " + prcSeven.Item2.ToString() + " ENABLE_ID -> " + prcSeven.Item3.ToString() + " UPDATE_DTTM-> " + prcSeven.Item4.ToString() + " UPDATE_UID-> " + prcSeven.Item5.ToString() + " ProcessStatus -> " + prcSeven.Item6.ToString());
            tstLog.WriteLine("               Step 2 Delete Record -> Process Status -> "+resTest7.ToString());
            tstLog.WriteLine("Application Table Testing End \n");
            cntTest++;
            //End Application Testing
            //Begin Batch Testing
            tstLog.WriteLine("Batch Table Testing Beginning");
            //Test 8: Define Batch
            int resTest8 = 0;
            resTest8 = Rover.DefineBatch(tstBATCHTYPE.ToString(),tstBATCHNM.ToString(),tstAPPID.ToString(),tstTESTERID.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Define Batch -> Process Results-> " + resTest8.ToString());
            cntTest++;
            //Test 9: Get Batch ID
            var rezValue8 = Rover.GetBatchID(tstBATCHNM.ToString());
            tstBATCHID = rezValue8.Item1.ToString();
            ProcStat = rezValue8.Item2;
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Test Batch ID ->" + tstBATCHID.ToString());
            cntTest++;
            //Test 10: Get Batch
            //Return Tuple Values BATCH_ID, BATCH_NM, BATCH_TYPE, ENABLE_IND, UPDATE_DTTM ,UPDATE_UID, ProcessStatus
            var rezTest10 = Rover.GetBatch(tstBATCHID.ToString(),tstBATCHNM.ToString());
            string strLine = " BATCH_ID -> "+ rezTest10.Item1.ToString()+" BATCH_NM-> "+ rezTest10.Item2.ToString()+" BATCH_TYPE-> "+ rezTest10.Item3.ToString() + " ENABLE_IND-> "+ rezTest10.Item4.ToString() + " UPDATE_DTTM-> "+ rezTest10.Item5.ToString()+" UPDATE_UID-> "+ rezTest10.Item6.ToString()+" ProcessStatus-> "+rezTest10.Item7.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Results Get Batch->> ");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 12: Disable Batch
            int resTest11 = 0;
            resTest11 = Rover.DisableBatch(tstBATCHID, tstTESTERID);
            var rezTest11 = Rover.GetBatch(tstBATCHID.ToString(), tstBATCHNM.ToString());
            strLine = " BATCH_ID -> " + rezTest11.Item1.ToString() + " BATCH_NM-> " + rezTest11.Item2.ToString() + " BATCH_TYPE-> " + rezTest11.Item3.ToString() + " ENABLE_IND-> " + rezTest11.Item4.ToString() + " UPDATE_DTTM-> " + rezTest11.Item5.ToString() + " UPDATE_UID-> " + rezTest11.Item6.ToString() + " ProcessStatus-> " + rezTest11.Item7.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": - Disable Batch: Process Results->" + resTest11.ToString());
            tstLog.WriteLine("           - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 12: Enable Batch
            int resTest12 = 0;
            resTest11 = Rover.EnableBatch(tstBATCHID.ToString(), tstTESTERID.ToString());
            var rezTest12 = Rover.GetBatch(tstBATCHID.ToString(), tstBATCHNM.ToString());
            strLine = " BATCH_ID -> " + rezTest12.Item1.ToString() + " BATCH_NM-> " + rezTest12.Item2.ToString() + " BATCH_TYPE-> " + rezTest12.Item3.ToString() + " ENABLE_IND-> " + rezTest12.Item4.ToString() + " UPDATE_DTTM-> " + rezTest12.Item5.ToString() + " UPDATE_UID-> " + rezTest12.Item6.ToString() + " ProcessStatus-> " + rezTest12.Item7.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": - Enable Batch: Process Results->" + resTest12.ToString());
            tstLog.WriteLine("          - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            // Test 13: Delete Batch
            //Create Batch to Delete
            resTest8 = Rover.DefineBatch(tstBATCHTYPE.ToString(), tstBATCHNMDEL.ToString(),tstAPPID.ToString(), tstTESTERID.ToString());
            rezValue8 = Rover.GetBatchID(tstBATCHNMDEL.ToString());
            string tstBATCHIDEL = rezValue8.Item1.ToString();
             //Validate it was created
            var rezTest13 = Rover.GetBatch(tstBATCHIDEL.ToString(), tstBATCHNMDEL.ToString());
            strLine = " BATCH_ID -> " + rezTest13.Item1.ToString() + "BATCH_NM-> " + rezTest13.Item2.ToString() + " BATCH_TYPE-> " + rezTest13.Item3.ToString() + " ENABLE_IND-> " + rezTest13.Item4.ToString() + " UPDATE_DTTM-> " + rezTest13.Item5.ToString() + " UPDATE_UID-> " + rezTest13.Item6.ToString() + " ProcessStatus-> " + rezTest13.Item7.ToString();
            //Delete
            //Validate it was deleted ("Tricky"
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Delete Batch-> Step 1 Create Batch ->");
            tstLog.WriteLine(strLine);
            int resTest13 = Rover.DeleteBatch(tstBATCHIDEL.ToString());
            tstLog.WriteLine("                        Step 2 Delete Batch -> Process Status-> " + resTest13.ToString());
            cntTest++;
            tstLog.WriteLine("Batch Table Testing End \n");
            //End Batch Testing
            //Begin Batch Control Testing
            tstLog.WriteLine("Batch Control Table Testing Beginning");
            //Test 14: Invoke Batch Control
            int resTest14 = 0;
            resTest14 = Rover.InvokeBatchControl(tstBATCHID.ToString(), tstBATCHCNTRLNM.ToString(),tstBATCHCNTRLDT,tstBATCHCNTRLACTVIND.ToString(), tstBATCHSTRTDTTM, tstBOUNDARYSTARTDT, tstBOUNDARYENDDT, tstTESTERID.ToString() );
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Invoke Batch Control  -> Process Results-> " + resTest14.ToString());
            //Test 15: Get Batch Control ID
            var rezTest15 = Rover.GetBatchControlID(tstBATCHCNTRLNM.ToString());
            tstBATCHCNTRLID = rezTest15.Item1.ToString();
            strLine = "BATCH CONTROL ID -> " + tstBATCHCNTRLID.ToString() + " Process Status-> " + rezTest15.Item2.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + " : Get Batch Control ID ");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 16: Get Batch Control Record
            var rezTest16 = Rover.GetBatchControl(tstBATCHCNTRLID.ToString(), tstBATCHCNTRLNM.ToString());
            strLine = "BATCH CONTROL ID  -> " + rezTest16.Item1.ToString() + " BATCH_CNTRL_NM-> " + rezTest16.Item2.ToString() + " BATCH_ID-> " + rezTest16.Item3.ToString() + " BATCH_CNTRL_DT-> " + rezTest16.Item4.ToString() + " BATCH_CNTRL_ACTV_IND-> " + rezTest16.Item5.ToString() + " UPDATE_UID- >" + rezTest16.Item6.ToString() + "BATCH_START_DTTM-> " + rezTest16.Rest.Item1.ToString() + " BATCH_END_DTTM-> " + rezTest16.Rest.Item2.ToString() + " BOUNDARY_START_DT-> " + rezTest16.Rest.Item3.ToString() + " BOUNDARY_END_DT-> " + rezTest16.Rest.Item4.ToString() + " UPDATE_DTTM-> " + rezTest16.Rest.Item5.ToString() + " ProcessStatus -> " + rezTest16.Item7.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Get Batch Control Record -> ");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 17: Update Batch Control Record
            int resTest19 = 0;
            resTest19 = Rover.UpdateBatchControl(tstBATCHCNTRLID.ToString(), tstBATCHCNTRLNM.ToString(), DateTime.Now, "Y", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, tstTESTERID.ToString());
            var rezTest19 = Rover.GetBatchControl(tstBATCHCNTRLID.ToString(), tstBATCHCNTRLNM.ToString());
            strLine = "BATCH CONTROL ID  ->" + rezTest19.Item1.ToString() + " BATCH_CNTRL_NM->" + rezTest19.Item2.ToString() + " BATCH_ID->" + rezTest19.Item3.ToString() + " BATCH_CNTRL_DT->" + rezTest19.Item4.ToString() + "BATCH_CNTRL_ACTV_IND-> " + rezTest19.Item5.ToString() + " UPDATE_UID-> " + rezTest19.Item6.ToString() + " BATCH_START_DTTM-> " + rezTest19.Rest.Item1.ToString() + " BATCH_END_DTTM-> " + rezTest19.Rest.Item2.ToString() + " BOUNDARY_START_DT-> " + rezTest19.Rest.Item3.ToString() + " BOUNDARY_END_DT-> " + rezTest19.Rest.Item4.ToString() + " UPDATE_DTTM-> " + rezTest19.Rest.Item5.ToString() + " ProcessStatus -> " + rezTest19.Item7.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + " : - Update Batch Control: Process Results-> " + resTest19.ToString());
            tstLog.WriteLine("            - Data For Validation->> ");
            tstLog.WriteLine(strLine);
            cntTest++;
            tstLog.WriteLine("Batch Control Table Testing End \n");
            //End Batch Control Testing
            //Begin Process Testing
            tstLog.WriteLine("Process Table Testing Beginning");
            //Test 18: Define Process
            int resTest20 = 0;
            resTest20 = Rover.DefineProcess(tstPROCESSIDNM.ToString(), tstBATCHID.ToString(), tstPROCESSTYPCD, tstPROCESSLOCATION, tstPROCESSNM, tstTESTERID);
            tstLog.WriteLine("Test " + cntTest.ToString() + " : Define Process Record  -> Process Results-> " + resTest20.ToString());
            cntTest++;
            //Test 19: Get Process ID
            var rezTest21 = Rover.GetProcessID(tstPROCESSIDNM.ToString());
            tstPROCESSID = rezTest21.Item1.ToString();
            strLine = "PROCESS ID -> " + tstPROCESSID.ToString() + " Process Status-> " + rezTest21.Item2.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + " : Get Process ID " + strLine);
            cntTest++;
            //Test 20: Get Process Record
            var rezTest22 = Rover.GetProcess(tstPROCESSID.ToString());
            strLine = "PROCESS_ID -> " + rezTest22.Item1.ToString() + " PROCESS_ID_NM-> " + rezTest22.Item2.ToString() + " BATCH_ID- >" + rezTest22.Item3.ToString() + " PROCESS_TYP_CD-> " + rezTest22.Item5.Item1.ToString() + " PROCESS_LOCATION-> " + rezTest22.Item5.Item2.ToString() + " PROCESS_NM-> " + rezTest22.Item5.Item3.ToString() + " ENABLE_IND-> " + rezTest22.Item5.Item4.ToString() + " UPDATE_DTTM-> " + rezTest22.Item5.Item5.ToString() + " UPDATE_UID -> " + rezTest22.Item5.Item6.ToString() + " ProcessStatus -> " + rezTest22.Item4.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + " : Get Process Record -> ");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 21: Disable Process
            int resTest23 = 0;
            resTest23 = Rover.DisableProcess(tstPROCESSID.ToString(), tstTESTERID.ToString());
            var rezTest23 = Rover.GetProcess(tstPROCESSID.ToString());
            strLine = "PROCESS_ID-> " + rezTest23.Item1.ToString() + " PROCESS_ID_NM-> " + rezTest23.Item2.ToString() + " BATCH_ID-> " + rezTest23.Item3.ToString() + " PROCESS_TYP_CD-> " + rezTest23.Item5.Item1.ToString() + " PROCESS_LOCATION-> " + rezTest23.Item5.Item2.ToString() + " PROCESS_NM-> " + rezTest23.Item5.Item3.ToString() + " ENABLE_IND-> " + rezTest23.Item5.Item4.ToString() + " UPDATE_DTTM-> " + rezTest23.Item5.Item5.ToString() + " UPDATE_UID -> " + rezTest23.Item5.Item6.ToString() + " ProcessStatus -> " + rezTest23.Item4.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + " : - Disable Process: Process Results->" + resTest23.ToString());
            tstLog.WriteLine("           - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 22: Enable Process
            int resTest24 = 0;
            resTest24 = Rover.DisableProcess(tstPROCESSID.ToString(), tstTESTERID.ToString());
            var rezTest24 = Rover.GetProcess(tstPROCESSID.ToString());
            strLine = "PROCESS_ID-> " + rezTest24.Item1.ToString() + " PROCESS_ID_NM-> " + rezTest24.Item2.ToString() + " BATCH_ID-> " + rezTest24.Item3.ToString() + " PROCESS_TYP_CD-> " + rezTest24.Item5.Item1.ToString() + " PROCESS_LOCATION-> " + rezTest24.Item5.Item2.ToString() + " PROCESS_NM-> " + rezTest24.Item5.Item3.ToString() + " ENABLE_IND-> " + rezTest24.Item5.Item4.ToString() + " UPDATE_DTTM-> " + rezTest24.Item5.Item5.ToString() + " UPDATE_UID -> " + rezTest24.Item5.Item6.ToString() + " ProcessStatus -> " + rezTest24.Item4.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + " : - Enable Process: Process Results-> " + resTest24.ToString());
            tstLog.WriteLine("          - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 23: Update Process
            int resTest25 = 0;
            resTest25 = Rover.UpdateProcess(tstPROCESSID.ToString(),tstPROCESSIDNM.ToString(),tstBATCHID.ToString(),"SCRIPT",tstPROCESSLOCATION.ToString(),tstPROCESSNM.ToString(),"Y",tstTESTERID.ToString());
            var rezTest25 = Rover.GetProcess(tstPROCESSID.ToString());
            strLine = "PROCESS_ID-> " + rezTest25.Item1.ToString() + " PROCESS_ID_NM-> " + rezTest25.Item2.ToString() + " BATCH_ID-> " + rezTest25.Item3.ToString() + " PROCESS_TYP_CD-> " + rezTest25.Item5.Item1.ToString() + " PROCESS_LOCATION->" + rezTest25.Item5.Item2.ToString() + " PROCESS_NM-> " + rezTest25.Item5.Item3.ToString() + " ENABLE_IND-> " + rezTest25.Item5.Item4.ToString() + " UPDATE_DTTM-> " + rezTest25.Item5.Item5.ToString() + " UPDATE_UID -> " + rezTest25.Item5.Item6.ToString() + " ProcessStatus-> " + rezTest25.Item4.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + " : - Update Process: Process Results-> " + resTest25.ToString());
            tstLog.WriteLine("          - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 24: Delete Process
            //Create record to Delete
            int resTest26 = 0;
            resTest26 = Rover.DefineProcess(tstDELPROCESSNM.ToString(), tstBATCHID.ToString(), tstPROCESSTYPCD, tstPROCESSLOCATION, tstPROCESSNM, tstTESTERID);;
            var rezTest261= Rover.GetProcessID(tstDELPROCESSNM.ToString());
            string tstPROCESSIDDEL = rezTest261.Item1.ToString();
            //Validate it was created
            var rezTest262 = Rover.GetProcess(tstPROCESSIDDEL.ToString());
            strLine="PROCESS_ID-> " + rezTest262.Item1.ToString() + " PROCESS_ID_NM-> " + rezTest262.Item2.ToString() + " BATCH_ID-> " + rezTest262.Item3.ToString() + " PROCESS_TYP_CD-> " + rezTest262.Item5.Item1.ToString() + " PROCESS_LOCATION-> " + rezTest262.Item5.Item2.ToString() + " PROCESS_NM-> " + rezTest262.Item5.Item3.ToString() + " ENABLE_IND-> " + rezTest262.Item5.Item4.ToString() + " UPDATE_DTTM-> " + rezTest262.Item5.Item5.ToString() + " UPDATE_UID -> " + rezTest262.Item5.Item6.ToString() + " ProcessStatus-> " + rezTest262.Item4.ToString();
            resTest26 = Rover.DeleteProcess(tstPROCESSIDDEL.ToString());
            //Delete
            //Validate it was deleted ("Tricky")
            tstLog.WriteLine("Test " + cntTest.ToString() + " : Delete Process-> Step 1 Create Process Record->");
            tstLog.WriteLine("                        "+strLine);
            tstLog.WriteLine("                         Step 2 Delete Process -> Process Status->" + resTest26.ToString());
            //var rezTest263 = Rover.GetProcess(tstPROCESSIDDEL.ToString());
            //strLine = "PROCESS_ID->" + rezTest263.Item1.ToString() + " PROCESS_ID_NM->" + rezTest263.Item2.ToString() + " BATCH_ID->" + rezTest263.Item3.ToString() + " PROCESS_TYP_CD->" + rezTest263.Item5.Item1.ToString() + " PROCESS_LOCATION->" + rezTest263.Item5.Item2.ToString() + " PROCESS_NM->" + rezTest263.Item5.Item3.ToString() + " ENABLE_IND->" + rezTest263.Item5.Item4.ToString() + " UPDATE_DTTM->" + rezTest263.Item5.Item5.ToString() + " UPDATE_UID" + rezTest263.Item5.Item6.ToString() + " ProcessStatus->" + rezTest263.Item4.ToString();
            cntTest++;
            tstLog.WriteLine("Process Table Testing End \n");
            //End Process Testing
            //Begin Audit Balance Defintion Testing
            tstLog.WriteLine("Audit Balance Defintion Table Testing Beginning");
            //Test 25: Insert Audit Balance Defintion
            int resTest27 = 0;
            resTest27 = Rover.InsertAuditBalanceDefinition(tstPROCESSID.ToString(), tstSOURCEEXPRESSIONTXT.ToString(), tstOPERAND.ToString(), tstTARGET_EXPRESSION_TXT.ToString(), tstABC_TYP_IND.ToString(), tstABCFAILCRITICALFLAG.ToString(), tstTESTERID.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Insert Audit Balance Defintion  -> Process Results-> " + resTest27.ToString());
            cntTest++;
            //Test 26: Get ABC Rule ID
            var rezTest28 = Rover.GetABCRuleID(tstPROCESSID.ToString(),tstSOURCEEXPRESSIONTXT.ToString());
            tstABCRULEID = rezTest28.Item1.ToString();
            strLine = "RULE ID ->" + tstABCRULEID.ToString() + " Process Status-> " + rezTest28.Item2.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Get ABC Rule ID" + strLine);
            cntTest++;
            //Test 27: Get Audit Balance Definition
            var rezTest29 = Rover.GetAuditBalanceDefinition(tstPROCESSID.ToString(), tstABCRULEID.ToString());
            strLine = "PROCESS_ID -> " + rezTest29.Item1.ToString() + " ABC_RULE_ID -> " + rezTest29.Item2.ToString() + " SOURCE_EXPRESSION_TXT ->" + rezTest29.Item6.Item1.ToString() + " OPERAND -> " + rezTest29.Item6.Item2.ToString() + " TARGET_EXPRESSION_TXT ->" + rezTest29.Item6.Item3.ToString() + " ABC_TYP_IND -> " + rezTest29.Item6.Item4.ToString() + " ABC_FAIL_CRITICAL_FLAG ->" + rezTest29.Item6.Item6.ToString() + " ENABLE_IND -> " + rezTest29.Item6.Item5.ToString() + " UPDATE_DTTM-> " + rezTest29.Item3.ToString() + " UPDATE_UID-> " + rezTest29.Item4.ToString() + " ProcessStatus -> " + rezTest29.Item5.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Get Audit Balance Definition");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 28: Disable Audit Balance Definition
            int resTest30 = 0;
            resTest30 = Rover.DisableAuditBalanceDefinition(tstABCRULEID, tstPROCESSID, tstTESTERID.ToString());
            var rezTest30 = Rover.GetAuditBalanceDefinition(tstPROCESSID.ToString(), tstABCRULEID.ToString());
            strLine = "RULE ID ->" + tstABCRULEID.ToString() + " Process Status-> " + rezTest21.Item2.ToString() + "PROCESS_ID -> " + rezTest30.Item1.ToString() + " ABC_RULE_ID -> " + rezTest30.Item2.ToString() + " SOURCE_EXPRESSION_TXT ->" + rezTest30.Item6.Item1.ToString() + " OPERAND -> " + rezTest30.Item6.Item2.ToString() + " TARGET_EXPRESSION_TXT ->" + rezTest30.Item6.Item3.ToString() + " ABC_TYP_IND -> " + rezTest30.Item6.Item4.ToString() + " ABC_FAIL_CRITICAL_FLAG ->" + rezTest30.Item6.Item6.ToString() + " ENABLE_IND -> " + rezTest30.Item6.Item5.ToString() + " UPDATE_DTTM-> " + rezTest30.Item3.ToString() + " UPDATE_UID-> " + rezTest30.Item4.ToString() + " ProcessStatus -> " + rezTest30.Item5.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": - Disable AuditBalanceDefinition: Process Results->" + resTest30.ToString());
            tstLog.WriteLine("           - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 29: Enable Audit Balance Defintion
            int resTest31 = 0;
            resTest31 = Rover.EnableAuditBalanceDefinition(tstABCRULEID, tstPROCESSID, tstTESTERID.ToString());
            var rezTest31 = Rover.GetAuditBalanceDefinition(tstPROCESSID.ToString(), tstABCRULEID.ToString());
            strLine = "RULE ID ->" + tstABCRULEID.ToString() + " Process Status-> " + rezTest21.Item2.ToString() + "PROCESS_ID -> " + rezTest31.Item1.ToString() + " ABC_RULE_ID -> " + rezTest31.Item2.ToString() + " SOURCE_EXPRESSION_TXT ->" + rezTest31.Item6.Item1.ToString() + " OPERAND -> " + rezTest31.Item6.Item2.ToString() + " TARGET_EXPRESSION_TXT ->" + rezTest31.Item6.Item3.ToString() + " ABC_TYP_IND -> " + rezTest31.Item6.Item4.ToString() + " ABC_FAIL_CRITICAL_FLAG ->" + rezTest31.Item6.Item6.ToString() + " ENABLE_IND -> " + rezTest31.Item6.Item5.ToString() + " UPDATE_DTTM-> " + rezTest31.Item3.ToString() + " UPDATE_UID-> " + rezTest31.Item4.ToString() + " ProcessStatus -> " + rezTest31.Item5.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": - Enable AuditBalanceDefinition: Process Results->" + resTest31.ToString());
            tstLog.WriteLine("          - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 30: Delete and Audit Balance Defintion
            int resTest32a = 0;
            resTest32a = Rover.InsertAuditBalanceDefinition(tstPROCESSID.ToString(), tstSOURCE_EXPRESSION_TXT_DEL.ToString(), tstOPERAND.ToString(), tstTARGET_EXPRESSION_TXT.ToString(), tstABC_TYP_IND.ToString(), tstCRITICAL_FAIL_IND.ToString(), tstTESTERID.ToString());
            var rezTest32b = Rover.GetABCRuleID(tstPROCESSID.ToString(), tstSOURCE_EXPRESSION_TXT_DEL.ToString());
            var rezTest32C = Rover.GetAuditBalanceDefinition(tstPROCESSID.ToString(), rezTest32b.Item1.ToString());
            strLine = "PROCESS_ID -> " + rezTest32C.Item1.ToString() + " ABC_RULE_ID -> " + rezTest32C.Item2.ToString() + " SOURCE_EXPRESSION_TXT -> " + rezTest32C.Item6.Item1.ToString() + " OPERAND -> " + rezTest32C.Item6.Item2.ToString() + " TARGET_EXPRESSION_TXT -> " + rezTest32C.Item6.Item3.ToString() + " ABC_TYP_IND -> " + rezTest32C.Item6.Item4.ToString() + " ABC_FAIL_CRITICAL_FLAG -> " + rezTest32C.Item6.Item6.ToString() + " ENABLE_IND -> " + rezTest32C.Item6.Item5.ToString() + " UPDATE_DTTM-> " + rezTest32C.Item3.ToString() + " UPDATE_UID-> " + rezTest32C.Item4.ToString() + " ProcessStatus -> " + rezTest32C.Item5.ToString();
            int resTest32b = 0;
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Delete Audit Balance Defintion-> Step 1 Create Audit Balance Defintion->");
            tstLog.WriteLine("          " + strLine);
            resTest32b = Rover.DeleteAuditBalanceDefinition(tstPROCESSID.ToString(), rezTest32b.Item1.ToString());
            tstLog.WriteLine("                         Step 2 Delete Audit Balance Defintion -> Process Status-> " + resTest32b.ToString());
            cntTest++;
            tstLog.WriteLine("Audit Balance Defintion Table Testing End \n");
            ////End Process Testing
            //Begin Process Control Testing
            tstLog.WriteLine("Process Control Table Testing Beginning");
            //Test 31: Define Process Control Instance
            int resTest33 = 0;
            resTest33 = Rover.DefineProcessControl(tstPROCESSID.ToString(), tstBATCHCNTRLID.ToString(), tstPROCESSCNTRLSTS.ToString(), tstPROCESSSTRDTTM, tstPROCESSENDDTTM);
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Define Process Control  -> Process Results-> " + resTest33.ToString());
            cntTest++;
            //Test 32: Get Process Control ID
            var rezTest34 = Rover.GetProcessControlID(tstPROCESSID.ToString(), tstBATCHCNTRLID.ToString());
            tstPROCESSCNTRLID = rezTest34.Item1.ToString();
            strLine = "PROCESS_CNTRL_ID -> " + tstPROCESSCNTRLID.ToString() + " Process Status-> " + rezTest34.Item2.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Get Process Control ID " + strLine);
            cntTest++;
            //Test 33: Get Process Control Record
            var rezTest35 = Rover.GetProcessControl(tstPROCESSCNTRLID.ToString());
            strLine = "PROCESS_CNTRL_ID -> " + rezTest35.Item1.ToString()  + " BATCH_CNTRL_ID -> " + rezTest35.Item3.Item1.ToString() + " PROCESS_ID -> " + rezTest35.Item3.Item2.ToString() + " PROCESS_CNTRL_STS -> " + rezTest35.Item3.Item3.ToString() + " PROCESS_STR_DTTM -> " + rezTest35.Item3.Item4.ToString() + " PROCESS_END_DTTM -> " + rezTest35.Item3.Item5.ToString() + " PROCESS_RESTR_CNTR -> " + rezTest35.Item3.Item6.ToString() + " PROCESS_INIT_STR_DTTM ->" + rezTest35.Item3.Item7.ToString() + " ProcessStatus ->" + rezTest35.Item2.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Get Process Control Record ->");
            cntTest++;
            tstLog.WriteLine(strLine);
            //Test 34: Update Process Control Record
            int resTest36 = 0;
            resTest36 = Rover.UpdateProcessControl(tstPROCESSCNTRLID.ToString(), tstBATCHCNTRLID.ToString(), tstPROCESSID.ToString(), "STARTED", tstPROCESSSTRDTTM, tstPROCESSENDDTTM, tstPROCESSRESTRCNTR, tstPROCESSINITSTRDTTM);
            var rezTest36 = Rover.GetProcessControl(tstPROCESSCNTRLID.ToString());
            strLine = "PROCESS_CNTRL_ID ->" + rezTest36.Item1.ToString() + " BATCH_CNTRL_ID -> " + rezTest36.Item3.Item1.ToString() + " PROCESS_ID -> " + rezTest36.Item3.Item2.ToString() + " PROCESS_CNTRL_STS -> " + rezTest36.Item3.Item3.ToString() + " PROCESS_STR_DDTM -> " + rezTest36.Item3.Item4.ToString() + " PROCESS_END_DTTM -> " + rezTest36.Item3.Item5.ToString() + " PROCESS_RESTR_CNTR -> " + rezTest36.Item3.Item6.ToString() + " PROCESS_INIT_STR_DTTM ->" + rezTest36.Item3.Item7.ToString() + " ProcessStatus ->" + rezTest36.Item2.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Update Process Control Record; Process Results->" + resTest36.ToString());
            tstLog.WriteLine("           - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            tstLog.WriteLine("Process Control Table Testing End \n");
            //End Process Control Testing
            //Begin Process Property Testing
            tstLog.WriteLine("Process Property Table Testing Beginning");
            //Test 35: Define Process Property
            int resTest37 = 0;
            resTest37 = Rover.DefineProcessProperty(tstPROCESSID.ToString(), tstPROPERTYNM.ToString(), tstPROPERTYVALUE.ToString(), tstPROPERTYVALUETYP.ToString(), tstTESTERID.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Define Process Property  -> Process Results-> " + resTest37.ToString());
            cntTest++;
            //Test 36: Get Process Property
            var rezTest38 = Rover.GetProcessProperty(tstPROCESSID.ToString(),tstPROPERTYNM.ToString());
            strLine = "PROCESS_ID ->" + rezTest38.Item1.ToString() + " PROPERTY_NM -> " + rezTest38.Item2.ToString() + " PROPERTY_VALUE -> " + rezTest38.Item4.Item1.ToString() + " PROPERTY_VALUE_TYP -> " + rezTest38.Item4.Item2.ToString() + " ENABLED_IND ->" + rezTest38.Item4.Item3.ToString() + " UPDATE_DTTM -> " + rezTest38.Item4.Item4.ToString() + " UPDATE_UID -> "+rezTest38.Item4.Item5.ToString() + " ProcessStatus -> " + rezTest38.Item3.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Get Process Property");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test xx: Get Process Properties
            int resTest39 = 0;
            int resCntr = 1;
            string strPropName1 = "Home Directory";
            string strPropValue1 = "C:\\WatchDog\\Home";
            string strPropName2 = "Default Directory";
            string strPropValue2 = "C:\\WatchDog";
            string strPropName3 = "Log File Directory";
            string strPropValue3 = "C:\\WatchDog\\Logs";
            string strPropName4 = "Error File Directory";
            string strPropValue4 = "C:\\WatchDog\\Errors";
            resTest39 = Rover.DefineProcessProperty(tstPROCESSID.ToString(), strPropName1.ToString(), strPropValue1.ToString(), tstPROPERTYVALUETYP.ToString(), tstTESTERID.ToString());
            resCntr++;
            resTest39 = Rover.DefineProcessProperty(tstPROCESSID.ToString(), strPropName2.ToString(), strPropValue2.ToString(), tstPROPERTYVALUETYP.ToString(), tstTESTERID.ToString());
            resCntr++;
            resTest39 = Rover.DefineProcessProperty(tstPROCESSID.ToString(), strPropName3.ToString(), strPropValue3.ToString(), tstPROPERTYVALUETYP.ToString(), tstTESTERID.ToString());
            resCntr++;
            resTest39 = Rover.DefineProcessProperty(tstPROCESSID.ToString(), strPropName4.ToString(), strPropValue4.ToString(), tstPROPERTYVALUETYP.ToString(), tstTESTERID.ToString());
            resCntr++;
            DataTable rsDT = Rover.GetProcessProperties(tstPROCESSID.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Get Process Properties");
            tstLog.WriteLine("                  :Step 1 -> Add additional Properties to "+ tstPROCESSID.ToString()+" for a total of "+resCntr.ToString()+" records.");
            tstLog.WriteLine("                  :Step 2 -> Output Records ->");
                for (int i = 0; i < rsDT.Rows.Count; i++)
                {
                DataRow dr = rsDT.Rows[i];
                tstLog.WriteLine("Record Number ->" + i.ToString() + " PROCESS_ID -> " + dr["PROCESS_ID"].ToString() + " PROPERTY_NM -> " + dr["PROPERTY_NM"].ToString() + " PROPERTY_VALUE -> " + dr["PROPERTY_VALUE"].ToString() + " PROPERTY_VALUE_TYP -> " + dr["PROPERTY_VALUE_TYP"].ToString() + " ENABLE_IND -> " + dr["ENABLE_IND"].ToString() + " UPDATE_DTTM ->" + (DateTime)dr["UPDATE_DTTM"] + " UPDATE_UID -> " + dr["UPDATE_UID"].ToString());
                }
            cntTest++;
            //Test 37: Disable Process Property
            int resTest40 = 0;
            resTest40=Rover.DisableProcessProperty(tstPROCESSID.ToString(), tstPROPERTYNM.ToString(),tstTESTERID.ToString());
            var rezTest40 = Rover.GetProcessProperty(tstPROCESSID.ToString(), tstPROPERTYNM.ToString());
            strLine = "PROCESS_ID ->" + rezTest40.Item1.ToString() + " PROPERTY_NM -> " + rezTest40.Item2.ToString() + " PROPERTY_VALUE -> " + rezTest40.Item4.Item1.ToString() + " PROPERTY_VALUE_TYP -> " + rezTest40.Item4.Item2.ToString() + " ENABLED_IND ->" + rezTest40.Item4.Item3.ToString() + " UPDATE_DTTM -> " + rezTest40.Item4.Item4.ToString() + " UPDATE_UID -> " + rezTest40.Item4.Item5.ToString() + " ProcessStatus -> " + rezTest40.Item3.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": - Disable Process Property: Process Results->" + resTest40.ToString());
            tstLog.WriteLine("         - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 38: Enable Process Property
            int resTest41 = 0;
            resTest41 = Rover.EnableProcessProperty(tstPROCESSID.ToString(), tstPROPERTYNM.ToString(), tstTESTERID.ToString());
            var rezTest41 = Rover.GetProcessProperty(tstPROCESSID.ToString(), tstPROPERTYNM.ToString());
            strLine = "PROCESS_ID ->" + rezTest41.Item1.ToString() + " PROPERTY_NM -> " + rezTest41.Item2.ToString() + " PROPERTY_VALUE -> " + rezTest41.Item4.Item1.ToString() + " PROPERTY_VALUE_TYP -> " + rezTest41.Item4.Item2.ToString() + " ENABLED_IND ->" + rezTest41.Item4.Item3.ToString() + " UPDATE_DTTM -> " + rezTest41.Item4.Item4.ToString() + " UPDATE_UID -> " + rezTest41.Item4.Item5.ToString() + " ProcessStatus -> " + rezTest41.Item3.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": - Enable Process Property: Process Results->" + resTest41.ToString());
            tstLog.WriteLine("         - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 39: Delete Process Property
            int resTest42 = 0;
            resTest42 = Rover.DefineProcessProperty(tstPROCESSID.ToString(), tstPROPERTYNMDEL.ToString(), tstPROPERTYVALUE.ToString(), tstPROPERTYVALUETYP.ToString(), tstTESTERID.ToString());
            var rezTest42 = Rover.GetProcessProperty(tstPROCESSID.ToString(), tstPROPERTYNMDEL.ToString());
            strLine = "PROCESS_ID ->" + rezTest42.Item1.ToString() + " PROPERTY_NM -> " + rezTest42.Item2.ToString() + " PROPERTY_VALUE -> " + rezTest42.Item4.Item1.ToString() + " PROPERTY_VALUE_TYP -> " + rezTest42.Item4.Item2.ToString() + " ENABLED_IND ->" + rezTest42.Item4.Item3.ToString() + " UPDATE_DTTM -> " + rezTest42.Item4.Item4.ToString() + " UPDATE_UID -> " + rezTest42.Item4.Item5.ToString() + " ProcessStatus -> " + rezTest42.Item3.ToString();
            int resTest42b = 0;
            resTest42b = Rover.DeleteProcessProperty(tstPROCESSID.ToString(), tstPROPERTYNMDEL.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Delete Process Property -> Step 1 Create Process Property->");
            tstLog.WriteLine("          " + strLine);
            tstLog.WriteLine("                         Step 2 Delete Audit Balance Defintion -> Process Status->" + resTest42b.ToString());
            cntTest++;
            tstLog.WriteLine("Process Property Table Testing End \n");
            //End Process Property Testing
            //Begin Process Control Stats Testing
            tstLog.WriteLine("Process Control Stats Table Testing Beginning");
            //Test 40: Define Process Control Stats
            int resTest43 = 0;
            resTest43 = Rover.DefineProcessControlStats(tstPROCESSCNTRLID.ToString(), tstPROCESSCNTRLSTATNM.ToString(), tstPROCESSCNTRLSTATDESC.ToString(), tstPROCESSCNTRLSTATTYP.ToString(), tstPROCESSCNTRLSTATVALU.ToString(), tstTESTERID.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Define Process Control Statistics  -> Process Results-> " + resTest43.ToString());
            cntTest++;
            //Test 41 Get Process Control Stats
            var rezTest44 = Rover.GetProcessControlStats(tstPROCESSCNTRLID.ToString(), tstPROCESSCNTRLSTATNM.ToString());
            strLine = "PROCESS_CNTRL_ID -> " + rezTest44.Item1.ToString() + " PROCESS_CNTRL_STAT_DESC -> " + rezTest44.Item2.ToString() + " PROCESS_CNTRL_STAT_NM -> " + rezTest44.Item3.ToString() + " PROCESS_CNTRL_STAT_TYP ->" + rezTest44.Item4.ToString() + " PROCESS_CNTRL_STAT_VALU -> " + rezTest44.Item5.ToString() + " UPDATE_DTTM -> " + rezTest44.Item6.ToString() + " UPDATE_UID -> "+rezTest44.Item7.ToString() + " ProcessStatus ->" + rezTest44.Rest.Item1.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Get Process Control Statistics -> ");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 42: Update Process Control Stats
            int resTest45 = 0;
            resTest45 = Rover.UpdateProcessControlStats(tstPROCESSCNTRLID.ToString(), tstPROCESSCNTRLSTATNM.ToString(), tstPROCESSCNTRLSTATDESC.ToString(), tstPROCESSCNTRLSTATTYP.ToString(), "Updated Record", tstTESTERID.ToString());
            var rezTest45 = Rover.GetProcessControlStats(tstPROCESSCNTRLID.ToString(), tstPROCESSCNTRLSTATNM.ToString());
            strLine = "PROCESS_CNTRL_ID -> " + rezTest45.Item1.ToString() + " PROCESS_CNTRL_STAT_DESC -> " + rezTest45.Item2.ToString() + " PROCESS_CNTRL_STAT_NM -> " + rezTest45.Item3.ToString() + " PROCESS_CNTRL_STAT_TYP ->" + rezTest45.Item4.ToString() + " PROCESS_CNTRL_STAT_VALU -> " + rezTest45.Item5.ToString() + " UPDATE_DTTM -> " + rezTest45.Item6.ToString() + " UPDATE_UID -> " + rezTest45.Item7.ToString() + " ProcessStatus ->" + rezTest45.Rest.Item1.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Update Process Control  StatusRecord; Process Results->" + resTest45.ToString());
            tstLog.WriteLine("          - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            tstLog.WriteLine("Process Control Stats Table Testing End \n");
            //End Process Control Stats Testing
            //Begin Process ABC Results Testing
            tstLog.WriteLine("ABC Result Table Testing Beginning");
            //Test 43: Store Process ABC Results
            int rezTest46 = 0;
            rezTest46 = Rover.StoreProcessABCResults(tstPROCESSID.ToString(), tstPROCESSCNTRLID.ToString(),tstABCRULEID.ToString(),tstEXPECTED_VALUE.ToString(), tstACTUAL_VALUE.ToString(), tstABC_PASS_IND.ToString(),tstPROCESS_BALANCE_IND.ToString(), tstPROCESS_CONTROL_IND.ToString(),tstPROCESS_AUDIT_IND.ToString(),tstCRITICAL_FAIL_IND.ToString(), tstTESTERID.ToString());
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Define Process Control Statistics  -> Process Results-> " + rezTest46.ToString());
            cntTest++;
            //Test 44: Get Process ABC Results
            var rezTest47 = Rover.GetProcessABCResult(tstPROCESSID.ToString(), tstPROCESSCNTRLID.ToString(), tstABCRULEID.ToString());
            strLine = "PROCESS_CNTRL_ID -> " + rezTest47.Item1.ToString() + " PROCESS_CNTRL_STAT_DESC -> " + rezTest47.Item2.ToString() + " PROCESS_CNTRL_STAT_NM -> " + rezTest47.Item3.ToString() + " PROCESS_CNTRL_STAT_TYP ->" + rezTest47.Item4.ToString() + " PROCESS_CNTRL_STAT_VALU -> " + rezTest47.Item5.ToString() + " UPDATE_DTTM -> " + rezTest47.Item6.ToString() + " UPDATE_UID -> " + rezTest47.Item7.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + ": Get Process ABC Results -> ");
            tstLog.WriteLine(strLine);
            cntTest++;
            //Test 45: Update Process ABC Results
            int resTest48 = 0;
            resTest48 = Rover.UpdateProcessABCResult(tstPROCESSID.ToString(), tstPROCESSCNTRLID.ToString(),tstABCRULEID.ToString(),tstEXPECTED_VALUE.ToString(), "Updated Value", tstABC_PASS_IND.ToString(),tstPROCESS_BALANCE_IND.ToString(), tstPROCESS_CONTROL_IND.ToString(),tstPROCESS_AUDIT_IND.ToString(),tstCRITICAL_FAIL_IND.ToString(), tstTESTERID.ToString());
            var rezTest48 = Rover.GetProcessABCResult(tstPROCESSID.ToString(), tstPROCESSCNTRLID.ToString(), tstABCRULEID.ToString());
            strLine = "PROCESS_ID -> " + rezTest48.Item1.ToString() + " PROCESS_CNTRL_ID ->" + rezTest48.Item2.ToString() + " ABC_RULE_ID -> " + rezTest48.Item3.ToString() + " UPDATE_DTTM -> " + rezTest48.Item4.ToString() + " UPDATE_UID -> " + rezTest48.Item5.ToString() + " ProcessStatus ->" + rezTest48.Item6.ToString() + "EXPECTED_VALUE -> " + rezTest48.Item7.Item1.ToString() + " ACTUAL_VALUE -> " + rezTest48.Item7.Item2.ToString() + " ABC_PASS_IND -> " + rezTest48.Item7.Item3.ToString() + " PROCESS_BALANCE_IND -> " + rezTest48.Item7.Item4.ToString() + " PROCESS_AUDIT_IND -> " + rezTest48.Item7.Item5.ToString() + " CRITICAL_FAIL_IND -> " + rezTest48.Item7.Item6.ToString();
            tstLog.WriteLine("Test " + cntTest.ToString() + " : Update Process ABC Results Record; Process Results->" + resTest48.ToString());
            tstLog.WriteLine("           - Data For Validation->>");
            tstLog.WriteLine(strLine);
            cntTest++;
            tstLog.WriteLine("ABC Result Table Testing End \n");
            tstLog.WriteLine("End WatchDog ABC Class library Test");
            }
        }
    }
