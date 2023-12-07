var ExibeListas = function () {

    let VeiculoId = $("#veiculos").val();
    let MotoristaId = $("#motoristas").val();

    $.ajax({
        type: "GET",
        url: "ListaVeiculos",
        success: function (result) {
            $("#veiculos").html(result);
        }
    });

    $.ajax({
        type: "GET",
        url: "ListaMotoristas",
        success: function (result) {
            $("#motoristas").html(result);
        }
    });
};
ExibeListas();


$("#salvar").on("click", function () {

    
    let VeiculoId = $("#veiculos").val();
    let MotoristaId = $("#motoristas").val();
    let Data = $("#DATA").val();
    let TipoCombustivel = $("#TipoCombustivel").val();
    let QuantidadeAbastecida = $("#DECIMAL").val();
    let Id = $("#abastecimentoId").val();
    debugger;
    let meg = "";
    let aviso = false;
    if (VeiculoId.length == 0) {
        meg += "Veiculo \n";
    } else if (MotoristaId.length == 0) {
        meg += "Motorista \n";
    } else if (Data.length == 0) {
        meg += "Data \n";
    } else if (TipoCombustivel.length == 0) {
        meg += "TipoCombustivel \n";
    } else if (QuantidadeAbastecida.length == 0) {
        meg += "QuantidadeAbastecida \n";
    }

    if (meg.length > 0) {
        alert("Favor Preencher " + meg);
    } else {

        $.ajax({
            type: "POST",
            url: "Criar",
            data: {
                Id: Id,
                VeiculoId: VeiculoId,
                MotoristaId: MotoristaId,
                Data: Data,
                TipoCombustivel: TipoCombustivel,
                QuantidadeAbastecida: QuantidadeAbastecida
            },
            success: function (result) {
                if (result == "OK") {
                    window.location.href = "Index";
                } else {
                    alert(result);
                }

               
            }
        });


    }
});