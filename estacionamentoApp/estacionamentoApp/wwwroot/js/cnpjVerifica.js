jQuery(function () {
    $("input[id=Cnpj]").change(function () {
        var cnpj = $(this).val().replace(/\D/g, ''); // Remove caracteres não numéricos
        if (cnpj.length !== 14) {
            alert("CNPJ inválido! Insira um CNPJ com 14 dígitos.");
            return;
        }

        // Faz a requisição GET para a Brasil API
        $.get(`https://brasilapi.com.br/api/cnpj/v1/${cnpj}`, function (result) {
            if (!result) {
                alert("CNPJ não encontrado ou inválido.");
                return;
            }

            // Preenche os campos com os dados da API
            $("input[id=NomeFantasia]").val(result.nome_fantasia || "");
            $("input[id=Nome]").val(result.razao_social || "");
        }).fail(function () {
            alert("Erro ao consultar o CNPJ. Tente novamente.");
        });
    });
});
