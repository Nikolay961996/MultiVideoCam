using Microsoft.AspNetCore.Mvc;

namespace MultiVideoCam.Controllers
{
    public static class ControllerExtensions
    {
        public static string Action<T>(this IUrlHelper urlHelper, string actionName)
            where T : Controller
        {
            var name = typeof(T).Name;
            var controllerName = name.EndsWith("Controller") ? name[..^10] : name;

            return urlHelper.Action(actionName, controllerName) ?? string.Empty;
        }
    }
}
