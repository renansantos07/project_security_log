
import Table from 'react-bootstrap/Table';

export const TableLog = (props: any) => {
    const {tableBody} = props;

    return (
        <Table className="mt-4" striped bordered hover>
            <thead>
                <tr>
                    <th className='col-2'>Data e Hora</th>
                    <th className='col-10'>Mensagem</th>
                </tr>
            </thead>
            {tableBody()}
        </Table>
    )
}