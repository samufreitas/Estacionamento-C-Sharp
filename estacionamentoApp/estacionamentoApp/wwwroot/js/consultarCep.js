jQuery(function () {
    $("input[id=Cep]").change(function () {
        var cep_code = $(this).val().replace(/\D/g, ''); // Remove caracteres não numéricos
        if (cep_code.length !== 8) {
            alert("CEP inválido! Insira um CEP com 8 dígitos.");
            return;
        }

        $.get(`https://viacep.com.br/ws/${cep_code}/json/`, function (result) {
            if (result.erro) {
                alert("CEP não encontrado.");
                return;
            }

            // Preenche os campos com os dados da API
            $("input[id=Estado]").val(result.uf || "");
            $("input[id=Cidade]").val(result.localidade || "");
            $("input[id=Bairro]").val(result.bairro || "");
            $("input[id=Rua]").val(result.logradouro || "");
            $("input[id=Pais]").val("Brasil"); // País é fixo
        }).fail(function () {
            alert("Erro ao consultar o CEP. Tente novamente.");
        });
    });
});
