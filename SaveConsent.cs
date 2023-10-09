  public async Task<HttpCustomResponseMessage> SaveGenerateConsent(PopulateGenerateConsent generateConsent)
        {
            try
            {

                await Task.Run(() => SaveGenerateConsentData(generateConsent));

                string primaryKey = generateConsent.PopulateGenerateConsentHeader[0].ConsentNo.ToString();

                HttpCustomResponseMessage response = new HttpCustomResponseMessage()
                {
                    Message = "Success",
                    HttpCode = 200,
                    PrimaryKey = primaryKey
                };

                return response;

            }

            catch (Exception ex)
            {
                HttpCustomResponseMessage response = new HttpCustomResponseMessage()
                {
                    HttpCode = 400,
                    Message = ex.Message
                };

                return response;
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opeartiveChecklistData"></param>
        private void SaveGenerateConsentData(PopulateGenerateConsent generateConsent)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {

                    Database database = Database.Create("defaultConnectionString");

                    SaveGenerateConsentHeader(generateConsent.PopulateGenerateConsentHeader[0], database);

                    SaveGenerateConsentDetail(generateConsent.PopulateGenerateConsentDetail, database, generateConsent.PopulateGenerateConsentHeader[0].ConsentNo);

                    transactionScope.Complete();

                }

                catch (Exception ex)
                {
                    transactionScope.Dispose();
                    throw ex;
                }
            }

        }
        private void SaveGenerateConsentHeader(GenerateConsentHeader consentHeader,Database database)
        {
            OracleCommand dbCommand = new OracleCommand();
            try
            {
                dbCommand = database.CreateStoreCommand("STP_SAVEGENERATECONSENTHEADER");

                database.AddInputParameter(dbCommand, "pConsentNo", OracleDbType.Varchar2, consentHeader.ConsentNo);
                database.AddInputParameter(dbCommand, "pConsentDate", OracleDbType.Date, consentHeader.ConsentDate);
                database.AddInputParameter(dbCommand, "pConsentTime", OracleDbType.Varchar2, consentHeader.ConsentTime);
                database.AddInputParameter(dbCommand, "pPatientId", OracleDbType.Varchar2, consentHeader.PatientId);
                if (consentHeader.OpNo == 0)
                {
                    consentHeader.OpNo=null;
                }
                else if(consentHeader.IpNo == 0) { consentHeader.IpNo=null; }
                database.AddInputParameter(dbCommand, "pIPNO", OracleDbType.Decimal, consentHeader.IpNo);
                database.AddInputParameter(dbCommand, "pOPNO", OracleDbType.Decimal, consentHeader.OpNo);
                database.AddInputParameter(dbCommand, "pProcScheduleNo", OracleDbType.Decimal, consentHeader.ProcedureScheduleNo);
                database.AddInputParameter(dbCommand, "pRecordCode", OracleDbType.Varchar2, consentHeader.RecordCode);
                database.AddInputParameter(dbCommand, "pTemplateNo", OracleDbType.Varchar2, consentHeader.TemplateNo);
                database.AddInputParameter(dbCommand, "pSignedBy", OracleDbType.Varchar2, consentHeader.SignedBy);
                database.AddInputParameter(dbCommand, "pSignedByName", OracleDbType.Varchar2, consentHeader.SignedByName);
                database.AddInputParameter(dbCommand, "pDoctorCode", OracleDbType.Varchar2, consentHeader.DoctorCode);
                database.AddInputParameter(dbCommand, "pCostCenterCode", OracleDbType.Varchar2, consentHeader.CostCenterCode);
                database.AddInputParameter(dbCommand, "pRemarks", OracleDbType.Varchar2, consentHeader.Remarks);
                database.AddInputParameter(dbCommand, "pUserIdm", OracleDbType.Varchar2, consentHeader.ModifiedUser);
                database.AddInputParameter(dbCommand, "pLocationCode", OracleDbType.Varchar2, consentHeader.LocationCode);
                database.AddInputParameter(dbCommand, "pMachineId", OracleDbType.Varchar2, consentHeader.MachineId);
                database.AddInputParameter(dbCommand, "pDeletedFlag", OracleDbType.Varchar2, consentHeader.DeletedFlag);
                database.AddInputParameter(dbCommand, "pConsentFormFileName", OracleDbType.Varchar2, consentHeader.ConsentFormFilename);
                database.AddOutputParameter(dbCommand, "pNewConsentNo", OracleDbType.Varchar2,25);

                using (OracleDataReader objReader = database.ExecuteReader(dbCommand))
                {

                    consentHeader.ConsentNo =dbCommand.Parameters["pNewConsentNo"].Value.ToString();

                }
             

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection != null)
                    {
                        dbCommand.Connection.Close();
                    }
                    dbCommand.Dispose();
                }
            }
        }
        private void SaveGenerateConsentDetail(List<GenerateConsentDetail> consentDetails, Database database,string ConsentNo)
        {
            OracleCommand dbCommand = new OracleCommand();
            try
            {
                DataTable dtTable = new DataTable();
                dtTable = MedinousClass.ToDataTable(consentDetails);

                dbCommand = database.CreateStoreCommand("STP_SAVEGENERATECONSENTDETAIL");

                database.AddInputParameter(dbCommand, "pConsentNo", OracleDbType.Varchar2, ConsentNo);
                database.AddInputParameter(dbCommand, "pConsentDetailNo", OracleDbType.Decimal, "DetailNo", DataRowVersion.Current);
                database.AddInputParameter(dbCommand, "pAdditionalFieldName", OracleDbType.Varchar2, "AdditionalFieldName", DataRowVersion.Current);
                database.AddInputParameter(dbCommand, "pAdditionalFieldValue", OracleDbType.Varchar2, "AdditionalFieldValue", DataRowVersion.Current);
                database.AddInputParameter(dbCommand, "pUser", OracleDbType.Varchar2, "ModifiedUser", DataRowVersion.Current);

                database.UpdateDataTable<DataTable>(dtTable, dbCommand, dbCommand, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbCommand != null)
                {
                    if (dbCommand.Connection != null)
                    {
                        dbCommand.Connection.Close();
                    }
                    dbCommand.Dispose();
                }
            }
        }
