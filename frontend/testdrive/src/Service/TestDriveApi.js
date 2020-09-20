import axios from 'axios';
const api = axios.create({
    baseURL: "http://localhost:5000"
  });


export default class TestDriveApi{

        async login(req){
            const resp = await api.post('/login', req);
            return resp;
        }

        async consultar(id) {
            const resp = await api.get(`/Cliente/Consultar/${id}`);
            console.log(resp.data)
          
            return resp.data;
        }

        async agendar(id,req) {
            const resp = await api.post(`/cliente/${id}`,req);
          
            return resp.data;
        }

        async feedback(id,req){
            const resp = await api.put(`/feedback/${id}`, req);
             return resp;
        }
    
}