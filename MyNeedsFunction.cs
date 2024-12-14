using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autopark
{
    internal class MyNeedsFunction
    {
        public MyNeedsFunction() { }
        public string GetQueryStringExpenses(string car_id)
        {
            return "SELECT "
                + " expenses.exp_id AS id, "
                + " expense_item.ei_title AS expense_name, "
                + " expenses.exp_amount AS amount, "
                + " expenses.exp_cmnt_id AS cmnt_id, "
                + " expenses.exp_ei_id AS ei_id, "
                + " expenses.exp_car_id AS car_id, "
                + " expenses.exp_description AS exp_description "
                + " FROM expenses "
                + " INNER JOIN expense_item ON expenses.exp_ei_id = expense_item.ei_id"
                + " WHERE expenses.exp_car_id = " + car_id
                + " ;";
        }
        public string GetQuerySelectMaintenances(string car_id)
        {
            return "SELECT " + // запрос списка ТО по автомобилю
                " maintenance.m_id AS m_id, " +
                " types_of_car_repair_work.tcrw_title AS tcrw_title, " +
                " maintenance.m_mileage AS m_mileage, " +
                " maintenance.m_date AS m_date, " +
                " maintenance_status.ms_status AS ms_status, " +
                " maintenance.m_ms_id AS ms_id, " +
                " maintenance.m_tcrw_id AS tcrw_id, " +
                " maintenance.m_car_id AS car_id, " +
                " maintenance.m_description AS m_description " +
                " FROM (maintenance " +
                " INNER JOIN types_of_car_repair_work " +
                " ON types_of_car_repair_work.tcrw_id = maintenance.m_tcrw_id) " +

                " INNER JOIN maintenance_status " +
                " ON maintenance_status.ms_id = maintenance.m_ms_id " +
                " WHERE maintenance.m_car_id = " + car_id +
                " ;";
        }
    }
}
