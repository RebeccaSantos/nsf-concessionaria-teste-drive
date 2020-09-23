import axios from 'axios';
const api = axios.create({
    baseURL: "http://localhost:5000/TestDrive"
  });


export default class TestDriveApi{

        async login(req){
            const resp = await api.post('/Login', req);
            return resp;
        }

        async consultar(id) {
            console.log(id);
            const resp = await api.get(`/Cliente/Consultar/${id}`);
            console.log(resp.data)
          
            return resp.data;
        }

        async agendar(req,id) {
            const resp = await api.post(`/cliente/${id}`,req);
          
            return resp.data;
        }

        async feedback(id,req){
            const resp = await api.put(`/feedback/${id}`, req);
             return resp;
        }

        async carros(){
            const resp = await api.get(`Consultar/Carro`);
             return resp;
        }
    
}