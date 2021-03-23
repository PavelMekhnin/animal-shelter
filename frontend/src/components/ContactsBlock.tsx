import React from "react";
import { IContact } from "../interfaces/Interfaces";

type ContactProps = {
    list: IContact[]
}

export const ContactsBlock = (data: ContactProps) => {
    if (data.list == null || data.list.length == 0) {
        return null;
    }
    return (
        <div className="left-info-block">
            <i className="material-icons">contact_phone</i>
            <ul>
                {data.list.map(c => {
                    return (
                        <li>
                            <p>{c.value} ({c.owner})</p>
                        </li>
                    )
                })}
            </ul>
        </div>
    )
}