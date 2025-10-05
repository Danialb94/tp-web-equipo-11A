<%@ Page Title="¡Felicidades!" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="Promo_web.Exito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .confetti {
            position: fixed;
            width: 10px;
            height: 10px;
            background-color: #f00;
            top: 0;
            animation: fall 3s linear infinite;
            opacity: 0.7;
            z-index: 9999;
        }

        @keyframes fall {
            to {
                transform: translateY(100vh) rotate(720deg);
            }
        }

        .fade-in {
            animation: fadeIn 1.5s ease-in forwards;
        }

        @keyframes fadeIn {
            from { opacity: 0; transform: scale(0.8); }
            to { opacity: 1; transform: scale(1); }
        }
    </style>

    <script>
        document.addEventListener("DOMContentLoaded", () => {
            for (let i = 0; i < 120; i++) {
                const confetto = document.createElement("div");
                confetto.classList.add("confetti");
                confetto.style.left = Math.random() * 100 + "vw";
                confetto.style.backgroundColor = `hsl(${Math.random() * 360}, 100%, 60%)`;
                confetto.style.animationDuration = 2 + Math.random() * 3 + "s";
                document.body.appendChild(confetto);
                setTimeout(() => confetto.remove(), 4000);
            }
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center mt-4 fade-in">
        <h1 class="text-success fw-bold display-4">🎉 ¡Felicidades! 🎉</h1>
        <p class="fs-4 mt-3">Tu canje fue exitoso. Pronto recibirás más información en tu correo electrónico.</p>

        <div class="mt-4">
            <asp:Image ID="imgPremio" runat="server" class="img-fluid object-fit-contain rounded-5 shadow" Style="width: 250px;height: 300px;"/>
            <h3 class="mt-3 text-primary">
                <asp:Label ID="lblPremio" runat="server" />
            </h3>
        </div>

        <div class="mt-4">
            <a href="Default.aspx" class="btn btn-lg btn-outline-dark">Volver al inicio</a>
        </div>
    </div>
</asp:Content>
