import React, { useEffect, useState } from "react";
import { UseSecurityLog } from "../../hooks/useSecurityLog";
import { FormFilter } from "../formFilter/formFilter";
import { TableLog } from "../tableLog/tableLog";

export const Main = () => {
    const { logs, getAll, getQuery } = UseSecurityLog();

    function onClickGetAll() {
        getAll();
    }

    function onClickGetQuery(initialDate: string, endDate: string, filter: string) {
        getQuery(initialDate, endDate, filter);
    }

    function tableBody() {
        return (
            <tbody>
                {
                    logs.map((item) => {
                        return (
                            <tr>
                                <td>{item.date.toString()}</td>
                                <td>{item.message}</td>
                            </tr>
                        )
                    })
                }
            </tbody>
        )
    }

    useEffect(() => {
        tableBody();
    }, [logs])

    return (
        <main role="main">
            <div className="album py-5 bg-light">
                <div className="container">
                    <FormFilter getAll={onClickGetAll} getQuery={onClickGetQuery}/>
                    <TableLog tableBody={tableBody} />
                </div>
            </div>
        </main>
    );
};