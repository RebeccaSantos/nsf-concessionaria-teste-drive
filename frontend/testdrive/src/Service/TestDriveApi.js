import axios from 'axios';


export default class TestDriveApi{
        async cadastrar(lf){
            const resp = await api.post('/testdrive', lf);
            return resp;
        }

        async consultar() {
            const resp = await api.get('/testdrive');
            console.log(resp.data)
          
            return resp.data;
        }

        async alterar(id,lf){
            const resp = await api.put('/testdrive/' + id, lf);
             return resp;
        }

        async excluir(id) {
            const resp = await api.delete('/testdrive/' + id);
          
            return resp.data;
        }
    
}