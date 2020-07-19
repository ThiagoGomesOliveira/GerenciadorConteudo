function ValidarExclusao (event) {

    if (confirm("Deseja excluir o registro!")) {
         return true;
    } else {
        event.preventDefault();
        return false;
    };
}