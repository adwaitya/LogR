﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Web.Messages
{
    public static class NotifyViewHelper
    {
        public static bool IsErrorMsgSet(this ViewContext helper)
        {
            if ((helper.TempData != null) && (helper.TempData.Keys.Any(item => item.Equals(NotifyMessageContants.ErrorMsg))))
            {
                return true;
            }
            return false;
        }

        public static bool IsInfoMsgSet(this ViewContext helper)
        {
            if ((helper.TempData != null) && (helper.TempData.Keys.Any(item => item.Equals(NotifyMessageContants.InfoMsg))))
            {
                return true;
            }
            return false;
        }

        public static bool IsWarningMsgSet(this ViewContext helper)
        {
            if ((helper.TempData != null) && (helper.TempData.Keys.Any(item => item.Equals(NotifyMessageContants.WarningMsg))))
            {
                return true;
            }
            return false;
        }

        public static bool IsSuccessMsgSet(this ViewContext helper)
        {
            if ((helper.TempData != null) && (helper.TempData.Keys.Any(item => item.Equals(NotifyMessageContants.SuccessMsg))))
            {
                return true;
            }
            return false;
        }

        public static bool IsShowCaptionSet(this ViewContext helper)
        {
            if ((helper.TempData != null) && (helper.TempData.Keys.Any(item => item.Equals(NotifyMessageContants.ShowCaption))))
            {
                return true;
            }
            return false;
        }

        public static bool IsErrorMsgSet(this HtmlHelper helper)
        {
            return helper.ViewContext.IsErrorMsgSet();
        }

        public static bool IsInfoMsgSet(this HtmlHelper helper)
        {
            return helper.ViewContext.IsInfoMsgSet();
        }

        public static bool IsWarningMsgSet(this HtmlHelper helper)
        {
            return helper.ViewContext.IsWarningMsgSet();
        }

        public static bool IsSuccessMsgSet(this HtmlHelper helper)
        {
            return helper.ViewContext.IsSuccessMsgSet();
        }

        public static bool IsShowCaptionSet(this HtmlHelper helper)
        {
            return helper.ViewContext.IsShowCaptionSet();
        }

        //
        public static HtmlString ShowErrorMsgIfSet(this ViewContext helper)
        {
            if (IsErrorMsgSet(helper))
            {
                return NotifyHtmlHelper.DisplayErrorMsg((string)helper.TempData[NotifyMessageContants.ErrorMsg]);
            }
            return new HtmlString("");
        }

        public static HtmlString ShowInfoMsgIfSet(this ViewContext helper)
        {
            if (IsInfoMsgSet(helper))
            {
                return NotifyHtmlHelper.DisplayInfoMsg((string)helper.TempData[NotifyMessageContants.InfoMsg]);
            }
            return new HtmlString("");
        }

        public static HtmlString ShowWarningMsgIfSet(this ViewContext helper)
        {
            if (IsWarningMsgSet(helper))
            {
                return NotifyHtmlHelper.DisplayWarningMsg((string)helper.TempData[NotifyMessageContants.WarningMsg]);
            }
            return new HtmlString("");
        }

        public static HtmlString ShowSuccessMsgIfSet(this ViewContext helper)
        {
            if (IsSuccessMsgSet(helper))
            {
                return NotifyHtmlHelper.DisplaySuccessMsg((string)helper.TempData[NotifyMessageContants.SuccessMsg]);
            }
            return new HtmlString("");
        }

        public static HtmlString ShowAllMessages(this ViewContext helper)
        {
            var sb = new StringBuilder();
            sb.Append(ShowErrorMsgIfSet(helper));
            sb.Append("");
            sb.Append(ShowInfoMsgIfSet(helper));
            sb.Append("");
            sb.Append(ShowWarningMsgIfSet(helper));
            sb.Append("");
            sb.Append(ShowSuccessMsgIfSet(helper));
            sb.Append("");
            return new HtmlString(sb.ToString());
        }
    }
}
