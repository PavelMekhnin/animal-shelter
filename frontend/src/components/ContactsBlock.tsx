import React from "react";
import { IContact } from "../interfaces/Interfaces";

type ContactProps = {
    list: IContact[]
}

export const ContactsBlock: React.FC<ContactProps> = ({ list }) => {
    if (list.length == 0) {
        return null;
    }
    return (
        <div className="left-info-block">
            <i className="material-icons">contact_phone</i>
            <ul>
                {list.map(c => {
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