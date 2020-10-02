import axios from 'axios';
const api = axios.create({
    baseURL: "http://localhost:5000"
  });


export default class TestDriveApi{

        async login(req){
            const resp = await api.post('/Login/Login', req);
            return resp;
        }

        async consultar(id) {
            console.log(id);
            const resp = await api.get(`/Cliente/Consultar/${id}`);
            console.log(resp.data)
          
            return resp.data;
        }

        async agendar(req,id) {
            const resp = await api.post(`/Cliente/${id}`,req);
          
            return resp.data;
        }

        async feedback(id,req){
            const resp = await api.put(`/Cliente/feedback/${id}`, req);
             return resp;
        }

        async carros(){
            const resp = await api.get(`/Carro/Consultar/Carro`);
             return resp;
        }

        async agendamentosDoDia(idFuncionario){
            const resp = await api.get(`/Funcionario/${idFuncionario}`);
            return resp;
        }

        async mudarSituacaoDogendamentoDoDia(idAgendamento, modeloSituacao){
            const resp = await api.put(`/Funcionario/alterar/${idAgendamento}`,modeloSituacao);
            return resp;
        }

        async listarAgendamentosParaAprovar(){
            const resp = await api.get(`/Funcionario/agendamentos`);
            return resp;

        }

        async aprovarAgendamentos(idAgendamento, idFuncionario){
            const resp = await api.put(`/Funcionario/aprovar/${idAgendamento}/${idFuncionario}`);
            return resp;
        }
    
}