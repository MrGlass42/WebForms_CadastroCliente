

jQuery(document).ready(function () {
    VerificarErros();
    AbrirModalParaEdicao();
    VerificarIntegracaoCEP();
    jQuery("#btn_modal_cadastro").on('click', function (e) {
        e.preventDefault();

        LimparModal();
        jQuery("#modal_cadastro_cliente").modal('show');
    });    
});

function VerificarErros() {
    if (jQuery("#MainContent_span_erro").html() != "") {
        jQuery("#modal_erro").modal('show');
        setTimeout(function () { jQuery("#modal_cadastro_cliente").modal('hide'); }, 500)
    }
}

function VerificarIntegracaoCEP() {
    if (jQuery("#MainContent_CampoCEP").val() != '' && jQuery("#MainContent_span_erro").html() == "")
        jQuery("#modal_cadastro_cliente").modal('show');
}

function LimparModal() {
    jQuery("input").val('');
    jQuery('textarea').val('');
}

function AbrirModalParaEdicao() {
    if (jQuery("#MainContent_CampoId").val() > 0)
        jQuery("#modal_cadastro_cliente").modal('show');
}