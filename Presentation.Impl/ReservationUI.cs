﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCSMS.Model;
using HCSMS.Model.Application;
using System.ServiceModel;

namespace HCSMS.Presentation.Impl
{
   public class ReservationUI:UserInterface,IReservationUI
    {
       public ReservationUI(Session session)
           : base(session)
       {
       }
        #region IReservationUI 成员

        public List<Table> GetAvailableTable(DateTime date)
        {
           
            
            using (DinningService.DinningServiceClient proxy = new DinningService.DinningServiceClient())
            {
                try
                {
                    proxy.Open();

                    return proxy.GetTable(date);
                   
                }
                catch (FaultException<HCSMSException> ex)
                {
                    raiseError(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    raiseError(ex);
                    return null;
                }
                finally
                {
                    proxy.Close();
                }
            }
        }
        public void MakeReservation(List<PreorderTable> tableList)
        {
            using (ReservationService.ReservationServiceClient proxy = new ReservationService.ReservationServiceClient())
            {
                try
                {
                    proxy.Open();
                    foreach (PreorderTable table in tableList)
                    {
                        proxy.MakeReservation(table);
                    }

                }
                catch (FaultException<HCSMSException> ex)
                {
                    raiseError(ex);
                }
                catch (Exception ex)
                {
                    raiseError(ex);
                }
                finally
                {
                    proxy.Close();
                }
            }
        }
        public void CancelReservation(List<PreorderTable> tableList)
        {
            using (ReservationService.ReservationServiceClient proxy = new ReservationService.ReservationServiceClient())
            {
                try
                {
                    proxy.Open();
                    foreach (PreorderTable table in tableList)
                    {
                        proxy.CancelReservation(table);
                    }

                }
                catch (FaultException<HCSMSException> ex)
                {
                    raiseError(ex);
                }
                catch (Exception ex)
                {
                    raiseError(ex);
                }
                finally
                {
                    proxy.Close();
                }
            }
        }
        public List<PreorderTable> GetReservation()
        {
            using (ReservationService.ReservationServiceClient proxy = new ReservationService.ReservationServiceClient())
            {
                try
                {
                    proxy.Open();

                    return proxy.GetReservationList().ToList();

                }
                catch (FaultException<HCSMSException> ex)
                {
                    raiseError(ex);
                    return null;
                }
                catch (Exception ex)
                {
                    raiseError(ex);
                    return null;
                }
                finally
                {
                    proxy.Close();
                }
            }
        }
        public void ChangeReservation(List<PreorderTable> tableList)
        {
            using (ReservationService.ReservationServiceClient proxy = new ReservationService.ReservationServiceClient())
            {
                try
                {
                    proxy.Open();
                    foreach (PreorderTable table in tableList)
                    {
                        proxy.ChangeReservation(table);
                    }

                }
                catch (FaultException<HCSMSException> ex)
                {
                    raiseError(ex);
                }
                catch (Exception ex)
                {
                    raiseError(ex);
                }
                finally
                {
                    proxy.Close();
                }
            }
        }

        #endregion
    }
  
}
