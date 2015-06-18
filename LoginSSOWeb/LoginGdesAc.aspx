<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginGdesAc.aspx.cs" Inherits="LoginSSOWeb.LoginGdesAc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function are_cookies_enabled() {
            var cookieEnabled = (navigator.cookieEnabled) ? true : false;
            if (typeof navigator.cookieEnabled == "undefined" && !cookieEnabled) {
                document.cookie = "testcookie";
                cookieEnabled = (document.cookie.indexOf("testcookie") != -1) ? true : false;
            }
            return (cookieEnabled);
        }

        function setCookie(c_name, value, exdays) {
            if (!are_cookies_enabled()) {
                alert("NO COOKIES");
            }
            var exdate = new Date();
            exdate.setDate(exdate.getDate() + exdays);
            var c_value = escape(value) + ((exdays === null) ? "" : "; expires=" + exdate.toUTCString());
            document.cookie = c_name + "=" + c_value + ";path=/";
        }

        function trabajadorCookie(id, name, login, idioma, evaluador, url) {
            //alert("ID:" + id +" Nombre:" + name + " Login:" + login + " Idioma:" + idioma + " Evaluador:" + evaluador);
            var data = {
                "trabajadorId": id,
                "nombre": name,
                "login": login,
                "idioma": idioma,
                "evaluador": evaluador
            };
            setCookie("trabajador", JSON.stringify(data), 1);
            window.open(url, '_self');
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
