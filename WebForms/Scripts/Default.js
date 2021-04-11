

jQuery(document).ready(function () {
    AbrirModalParaEdicao();

    jQuery("#btn_modal_cadastro").on('click', function (e) {
        e.preventDefault();

        LimparModal();
        jQuery("#modal_cadastro_cliente").modal('show');
    });    
});

function LimparModal() {
    jQuery("input").val('');
    jQuery('textarea').val('');
}

function AbrirModalParaEdicao() {
    if (jQuery("#MainContent_CampoId").val() > 0)
        jQuery("#modal_cadastro_cliente").modal('show');
}