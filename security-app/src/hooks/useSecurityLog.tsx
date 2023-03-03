import { useCallback, useState } from "react"
import ISecurityLog from "../interfaces/IsecurityLog";
import { SecurityLogService } from "../services/securityLogService";
import Swal from 'sweetalert2'

export const UseSecurityLog = () => {
    const [logs, setLogs] = useState<ISecurityLog[]>([])

    const validationError = (error: any) => {
        console.log(error);
        if(error.response.status === 404){
            Swal.fire({
                icon: 'warning',
                title: 'Nenhum dado encontrado!',
                text: 'Certifique-se que a extração dos dados já foi feita. Verifique o filtro e tente novamente!',
            })
        }else if (error.response.status >= 400 && error.response.status < 500) {

            Swal.fire({
                icon: 'warning',
                title: 'Dados inválidos'
            })
        } else if (error.response.status >= 500) {
            Swal.fire({
                icon: 'warning',
                title: 'Erro interno',
                text: 'estamos com problema, tente novamente',
            })
        }
    }

    const getAll = useCallback(async () => {
        setLogs([]);
        try {
            const { status, data } = await SecurityLogService.getAll();
            
            setLogs(data);
        } catch (error: any) {
            validationError(error);
        }
    }, []);

    const getQuery = useCallback(async (initialDate: string, endDate: string, filter: string) => {
        setLogs([]);
        try {
            const { status, data } = await SecurityLogService.getQuery(initialDate, endDate, filter);

            setLogs(data);
        } catch (error: any) {
            validationError(error);
        }
    }, []);

    return {
        logs,
        getAll,
        getQuery
    }
}