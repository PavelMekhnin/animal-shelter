import React from 'react';
import { IVolunteerCard } from '../interfaces/Interfaces';
import { VolunteerCardPreview } from './VolunteerCardPreview';

type VolunteerList = {
    list: IVolunteerCard[]
}

export const VolunteerCardList: React.FC<VolunteerList> = ({ list}) => {
    if (list == null || list.length == 0) {
        return (<span>У питомца нет кураторов :(</span>)
    }
    return (
        <>
            <div>
                {list.map(card => {
                    return (
                        <VolunteerCardPreview card={card}></VolunteerCardPreview>
                    )
                })
                }
            </div>
        </>
    )

}