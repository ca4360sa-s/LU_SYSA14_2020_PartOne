using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LU_SYSA14_2020_PartOne
{
    static class ModelViews
    {
        public static Start start = new Start(); 
        public static Views.ProgramConstructionOne programConstructionOne = new Views.ProgramConstructionOne();
        public static Views.ProgramConstructionTwo programConstructionTwo = new Views.ProgramConstructionTwo(); 
        public static Views.IntegrationTechnologiesOne integrationTechnologiesOne = new Views.IntegrationTechnologiesOne();
        public static Views.IntegrationTechnologiesTwo integrationTechnologiesTwo = new Views.IntegrationTechnologiesTwo();
        public static Views.IntegrationAndConfigurationOne integrationAndConfigurationOne = new Views.IntegrationAndConfigurationOne();
        public static Views.IntegrationAndConfigurationTwo integrationAndConfigurationTwo = new Views.IntegrationAndConfigurationTwo();
        public static Views.ProgramConstructionOneSubViews.OrderAndStockSystem productAndStockHandler = new Views.ProgramConstructionOneSubViews.OrderAndStockSystem(); 
    }

}
