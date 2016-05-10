
/*
$("#DpdProdutos").change(function () {
    var valor = $(this).val();   
    $("#txtPreco").val($(this).val());
    $("#txtPreco").val($(this).find("option:Preco").text());
});



//Obtendo valor do produto sem recarregar

$(document).ready(function () {
  
});

function RecPrd(prd) {


    var idPrd = $(this).val();

    $.ajax({
        dataType: "json",
        type: "POST",
        url: "/Carrinho/GetDadosProdutos",
        data: { id: idPrd },
        success: function (dados) {
            $("#txtPreco").val(dados);
        }
    });

}
*/
