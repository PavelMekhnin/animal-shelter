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
            <span>Контакты</span>
            <ul>
                {list.map(c => {
                    return (
                        <li>
                            <p>
                                {c.value}
                            </p>
                            <p>({c.owner})</p>
                        </li>
                    )
                })}
            </ul>
        </div>
    )
}