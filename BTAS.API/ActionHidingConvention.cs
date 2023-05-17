using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace BTAS.API
{
    public class ActionHidingConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            // Replace with any logic you want
            if (action.Controller.ControllerName == "Service" ||
                action.Controller.ControllerName == "CarrierInfo")
            {
                action.ApiExplorer.IsVisible = false;
            }

            if (action.Controller.ControllerName == "Shipment")
            {
                if(action.ActionMethod.Name == "GetAsync" ||
                   action.ActionMethod.Name == "PostAsync" ||
                   action.ActionMethod.Name == "PutAsync" ||
                   action.ActionMethod.Name == "DeleteAsync")
                {
                    action.ApiExplorer.IsVisible = false;
                } 
            }

            if (action.Controller.ControllerName == "Master" ||
                action.Controller.ControllerName == "House")
            {
                if (action.ActionMethod.Name == "DeleteAsync")
                {
                    action.ApiExplorer.IsVisible = false;
                }
            }
        }
    }
}
