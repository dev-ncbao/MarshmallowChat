import { Link } from 'react-router-dom';
import { useState } from 'react';
import clsx from 'clsx';
import { useNavigate } from 'react-router-dom';
//
import styles from './Register.module.css';
import { InputLarge, InputSmall, ButtonRounded, InputRadio } from './../../components';
import { CardLarge, AppContainer } from '../../containers';
import { UserValidation } from './../../validations';
import { user } from './../../apis';
import { https } from './../../constants';

function Register() {
    const [account, setAccount] = useState({
        FirstName: '',
        LastName: '',
        Gender: 'Nam',
        DayOfBirth: new Date().toISOString().substring(0, 10),
        Email: '',
        Username: '',
        Password: '',
        PasswordSecondary: ''
    });
    const [validations, setValidations] = useState({
        FirstName: {},
        LastName: {},
        Gender: {},
        DayOfBirth: {},
        Email: {},
        Username: {},
        Password: {},
        PasswordSecondary: {},
        ServerResponse: {}
    });
    const [registered, setRegistered] = useState(false);
    const navigate = useNavigate();

    const validationUser = () => {
        let validColumns = { ...validations };
        validColumns.FirstName = UserValidation.firstName(account.FirstName);
        validColumns.LastName = UserValidation.lastName(account.LastName);
        validColumns.Gender = UserValidation.gender(account.Gender);
        validColumns.DayOfBirth = UserValidation.dayOfBirth(account.DayOfBirth);
        validColumns.Username = UserValidation.username(account.Username);
        validColumns.Email = UserValidation.email(account.Email);
        validColumns.Password = UserValidation.password(account.Password);
        validColumns.PasswordSecondary = UserValidation.passwordSecondary(account.PasswordSecondary, account.Password);
        let isAllValid = true;
        for (const column in validColumns) {
            if (validColumns[column].isValid === false) {
                isAllValid = false;
                break;
            }
        }
        if (isAllValid)
            return true;
        else {
            setValidations(validColumns);
            return false;
        }
    }

    const handleRegister = async () => {
        if (registered) {
            navigate('/login');
        } else {
            let isValid = validationUser();
            let user = { ...account };
            delete user.PasswordSecondary;
            if (isValid) {
                const response = await user.post(JSON.stringify(user));
                if(!response)
                if (response.status === https.STATUS_CODE.CONFLICT
                    || response.status === https.STATUS_CODE.INTERNAL_SERVER_ERROR) {
                    response.clone().json().then(data => {
                        let validColumns = { ...validations };
                        validColumns.ServerResponse = { message: data.message };
                        setValidations(validColumns);
                    });
                }
                else if (response.status === https.STATUS_CODE.CREATED) {
                    setRegistered(true);
                }
            }
        }
    }

    const handleChange = (e) => {
        setAccount(prevState => ({
            ...prevState,
            [e.target.name]: e.target.value
        }))
    }

    return (
        <AppContainer>
            <div className={styles.container}>
                <CardLarge>
                    <label className={'text-headline-1'}>????ng k?? t??i kho???n</label>
                    {registered ?
                        <div>
                            <span className={styles.content}>????ng k?? t??i kho???n th??nh c??ng.</span>
                        </div>
                        : <>
                            <div className={clsx('d-flex', styles.inputFlexGap)}>
                                <div>
                                    <InputSmall
                                        input={{ onChange: handleChange, name: 'FirstName', type: 'text', value: account.FirstName }}
                                        label='H??? v?? t??n l??t'
                                    />
                                </div>
                                <div>
                                    <InputSmall
                                        input={{ onChange: handleChange, name: 'LastName', type: 'text', value: account.LastName }}
                                        label='T??n'
                                    />
                                </div>
                            </div>
                            <div className={clsx('d-flex', styles.inputFlexGap)}>
                                <div>
                                    <InputRadio
                                        onChange={handleChange}
                                        name='Gender'
                                        label='Gi???i t??nh'
                                        sources={['Nam', 'N???', 'Kh??c']}
                                        value={account.Gender}
                                    />
                                </div>
                                <div>
                                    <InputSmall
                                        input={{
                                            onChange: handleChange,
                                            name: 'DayOfBirth',
                                            type: 'date',
                                            value: account.DayOfBirth,
                                            max: new Date().toISOString().substring(0, 10),
                                            min: new Date(new Date().setFullYear(new Date().getFullYear() - 120)).toISOString().substring(0, 10),
                                        }}
                                        label='Ng??y sinh'
                                    />
                                </div>
                            </div>
                            <div>
                                <InputLarge
                                    input={{ value: account.Username, onChange: handleChange, name: 'Username', type: 'text' }}
                                    label='T??n ????ng nh???p'
                                    helperText='????? d??i 8 - 20 k?? t???'
                                />
                            </div>
                            <div>
                                <InputLarge
                                    input={{ onChange: handleChange, name: 'Email', type: 'text', value: account.Email }}
                                    label='Email'
                                />
                            </div>
                            <div>
                                <InputLarge
                                    input={{ onChange: handleChange, name: 'Password', type: 'password', value: account.Password }}
                                    label='M???t kh???u'
                                    helperText={`????? d??i 8 - 20 k?? t???${'\n'}Ph???i bao g???m: Ch??? in hoa, ch??? th?????ng, ch??? s??? v?? k?? t??? ?????c bi???t`}
                                />
                            </div>
                            <div>
                                <InputLarge
                                    input={{ onChange: handleChange, name: 'PasswordSecondary', type: 'password', value: account.PasswordSecondary }}
                                    label='Nh???p l???i m???t kh???u'
                                />
                            </div>
                        </>}
                    <div className={clsx('d-flex', styles.buttonContainer, 'align-center')}>
                        {!registered && <>
                            <div className={styles.validationMessage}>
                                <ul className='text-body-4'>
                                    {
                                        Object.values(validations).map((validation, index) => {
                                            return <li key={index}>{validation.message}</li>;
                                        })
                                    }
                                </ul>
                            </div>
                        </>}
                        <ButtonRounded onClick={handleRegister} >{registered ? 'Tr??? v??? ????ng nh???p' : '????ng k??'}</ButtonRounded>
                        {!registered && <span>???? c?? t??i kho???n? <Link to='/login' className={clsx('user-select-none', 'clear-a-tag', 'link-color', 'text-body-1')}>????ng nh???p</Link></span>}
                    </div>
                </CardLarge>
            </div>
        </AppContainer>
    );
}

export default Register