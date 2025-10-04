<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="Promo_web.Exito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    .gift-container {
        position: relative;
        width: 250px;
        margin: 50px auto;
        text-align: center;
    }

    .gift-box {
        width: 250px;
        height: 200px;
        background: url('images/caja-abierta.png') no-repeat center center;
        background-size: contain;
        position: relative;
    }

    .prize-img {
        width: 120px;
        position: absolute;
        top: 50px;
        left: 50%;
        transform: translateX(-50%);
    }

    .message {
        margin-top: 20px;
        font-size: 1.5rem;
        font-weight: bold;
        color: #198754;
    }

    canvas {
        position: fixed;
        top: 0;
        left: 0;
        pointer-events: none;
        z-index: 9999;
    }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="gift-container">
    <div class="gift-box">
        <asp:Image ID="imgPremio" runat="server" CssClass="prize-img" />
    </div>
    <div class="message">
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </div>
</div>

<canvas id="confetti-canvas"></canvas>
<script src="https://cdn.jsdelivr.net/npm/canvas-confetti@1.6.0/dist/confetti.browser.min.js"></script>
<script>
    window.onload = () => {
        // Lanzar confeti por 3 segundos
        const duration = 3 * 1000;
        const end = Date.now() + duration;

        (function frame() {
            confetti({
                particleCount: 7,
                spread: 70,
                origin: { y: 0.6 }
            });
            if (Date.now() < end) {
                requestAnimationFrame(frame);
            }
        })();
    };
</script>
</asp:Content>
