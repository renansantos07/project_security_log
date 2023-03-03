import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import React, { useEffect, useState } from "react";

export const FormFilter = (props: any) => {
    const [initialDate, SetInitialDate] = useState<string>("2022-11-30 00:00");
    const [endDate, SetEndDate] = useState<string>("2022-11-30 12:59");
    const [filter, SetFilter] = useState<string>("");
    const { getAll, getQuery } = props;

    const inputHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        const value = event.target.value;
        const name = event.target.name;

        if (name === "initialDate") {
            SetInitialDate(value);
        } else if (name === "endDate") {
            SetEndDate(value);
        } else {
            SetFilter(value);
        }
    };

    const get = () => {
        if(initialDate && endDate || filter){
            getQuery(initialDate, endDate, filter)
        }else{
            getAll()
        }
    }
    
    return (
        < Form >
            <div className="row">
                <div className="col-4">
                    <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                        <Form.Label>Initial Date</Form.Label>
                        <Form.Control type="text" placeholder="2022-11-30 00:00" value={initialDate} onChange={inputHandler} name="initialDate" />
                    </Form.Group>
                </div>
                <div className="col-4">
                    <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                        <Form.Label>End Date</Form.Label>
                        <Form.Control type="text" placeholder="2022-11-30 12:59" value={endDate} onChange={inputHandler} name="endDate" />
                    </Form.Group>
                </div>
                <div className="col-4">
                    <Form.Group className="mb-3" controlId="exampleForm.ControlInput1">
                        <Form.Label>Busca</Form.Label>
                        <Form.Control type="text" value={filter} onChange={inputHandler} name="filter" />
                    </Form.Group>
                </div>
            </div>
            <div className='row'>
                <div className="col-12 text-end">
                    <Button variant="primary" onClick={get}>Consultar</Button>
                </div>
            </div>
        </Form >
    )
}